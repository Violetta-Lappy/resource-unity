/**
 * author: hoanglongplanner
 * date: Jan 2th 2022
 * des: All logic of Match3 Game
 */

using System.Collections.Generic;
using UnityEngine;

public enum ENUM_GRID_TYPE {
    CLOSE,
    OPEN
}

public enum ENUM_GAMEELEMENT_TYPE {
    EMPTY,
    RED,
    BLUE,
    YELLOW,
    GREEN,
    ORANGE
}

public class Match3Settings {
    public const float K_GAME_WAIT_TIME = 0.075f;
}

public class ManagerMatch3 : SingletonBlank<ManagerMatch3> {

    /*VARIABLES*/
    public SODatabaseGameAsset m_database; //game-asset-database-to-reference

    //gameboard
    public int i32_width = 10;
    public int i32_height = 10;
    public int i32_space = 128;
    public int[,] i32_sz_gameBoard;
    public GameElement[,] m_sz_gameElement; //2D-array-contains-all-game-element    

    //other
    public GameElement m_currentGameElement; //the tile player currently clicks on
    public GameElement m_targetGameElement; //the tile player want to switch to

    //progress-checking
    private bool _isInProgress = false;
    public bool IsInProgress {
        get { return _isInProgress; }
        set {
            _isInProgress = value;
            GUIManager.Instance.DoGUIElementObject(ENUM_GUIELEMENT_OBJECT_TYPE.IN_PROGRESS_GAME, _isInProgress);
        }
    }
    private bool isDoneInitBoard = false;

    /*PROCESSORS*/
    public override void SingletonAwake() { }

    void Start() {

        if (m_database == null) return; //must-have-database-insert
        
        m_sz_gameElement = new GameElement[i32_width, i32_height]; //setup-array

        //setup-gameboard
        i32_sz_gameBoard = new int[10, 10] {
            {0,0,0,1,1,1,1,0,0,0},
            {0,0,1,1,1,1,1,1,0,0},
            {0,1,1,1,1,1,1,1,1,0},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,0,0,1,1,1,1},
            {1,1,1,1,0,0,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {0,1,1,1,1,1,1,1,1,0},
            {0,0,1,1,1,1,1,1,0,0},
            {0,0,0,1,1,1,1,0,0,0},
        };

        GameBoardSetup();
    }    

    public void GameBoardSetup() {
        for (int col = 0; col < i32_height; col++) {
            for (int row = 0; row < i32_width; row++) {
                float posX = this.transform.position.x;
                float posY = this.transform.position.y;

                //distribute-items
                //start-from-bottom-left at central axis of this object
                //Even Math Position: currentPosition + (i * space) + (space * 1/2)
                //Odd Math Position: currentPosition + (i * space)                
                if (i32_width % 2 == 0) posX = this.transform.position.x + ((row - (i32_width / 2)) * i32_space) + (i32_space / 2);
                if (i32_width % 2 != 0) posX = this.transform.position.x + ((row - (i32_width / 2)) * i32_space);
                if (i32_height % 2 == 0) posY = this.transform.position.y + ((col - (i32_height / 2)) * i32_space) + (i32_space / 2);
                if (i32_height % 2 != 0) posY = this.transform.position.y + ((col - (i32_height / 2)) * i32_space);

                //calc-final-position
                Vector3 finalPos = new Vector3(posX, posY, 0);

                //spawn-new-object
                GameObject tempGameObject = Instantiate(m_database.m_prefab
                    , finalPos
                    , Quaternion.identity, this.transform);

                //rename
                tempGameObject.name = "GameElement (" + row + "," + col + ")";

                //setup-game-board-based-on-CLOSED-or-OPEN
                m_sz_gameElement[row, col] = tempGameObject.GetComponent<GameElement>();
                if (i32_sz_gameBoard[row, col] == (int)ENUM_GRID_TYPE.CLOSE) {
                    m_sz_gameElement[row, col].Setup(row, col, finalPos, ENUM_GRID_TYPE.CLOSE, ENUM_GAMEELEMENT_TYPE.EMPTY);
                    continue;
                }

                //setup-game-element-in-array-element
                int randomID = Random.Range(1, m_database.m_sz_gameElementSprites.Length); //skip-Empty-GameElement-Type                
                m_sz_gameElement[row, col].Setup(row, col, finalPos, ENUM_GRID_TYPE.OPEN, (ENUM_GAMEELEMENT_TYPE)randomID);
            }
        }

        //check-matches-and-refill
        StartCoroutine(GameBoardFillRandom());
    }

    public void DoGameBoardShuffle() {
        if (IsInProgress) return; //safe-check

        IsInProgress = true; //IMPORTANT

        for (int col = 0; col < i32_height; col++) {
            for (int row = 0; row < i32_width; row++) {                               
                m_sz_gameElement[row, col].SetGameElementType(ENUM_GAMEELEMENT_TYPE.EMPTY);
            }
        }

        StartCoroutine(GameBoardFillRandom());
    }    

    private List<GameElement> GetListMatches(GameElement targetGameElement) {
        List<GameElement> list_horz = new List<GameElement>();
        List<GameElement> list_vert = new List<GameElement>();
        List<GameElement> list_matches = new List<GameElement>();

        //horizontal-check
        list_horz.Add(targetGameElement);

        //check-left-and-right-direction-of-horizontal
        for (int dir = 0; dir <= 1; dir++) {
            //loop-all-horizontal-gameelements
            for (int i = 1; i < i32_width; i++) {

                int tempX;

                if (dir == 0) tempX = targetGameElement.i32_idX - i; //left-horizontal
                else tempX = targetGameElement.i32_idX + i; //right-horizontal

                //out-of-bounds, safe-check, break-out-loop
                if (tempX < 0 || tempX >= i32_width) break;
                if (m_sz_gameElement[tempX, targetGameElement.i32_idY].enum_gridType == ENUM_GRID_TYPE.CLOSE) break;

                //check game element type
                if (m_sz_gameElement[tempX, targetGameElement.i32_idY].enum_gameElementType == targetGameElement.enum_gameElementType) {
                    list_horz.Add(m_sz_gameElement[tempX, targetGameElement.i32_idY]);
                } else break; //break-out-loop-if-found-different-gameelement
            }
        }

        //add-horizontal-matches-to-matches
        if (list_horz.Count < 3) list_horz = null; //clear-list-if-no-matches-found        

        //vertical-Check        
        list_vert.Add(targetGameElement); //add-target-element-if-horz-list-empty

        for (int dir = 0; dir <= 1; dir++) {
            for (int i = 1; i < i32_height; i++) {

                int tempY;

                if (dir == 0) tempY = targetGameElement.i32_idY - i; //down-vertical
                else tempY = targetGameElement.i32_idY + i; //up-vertical

                // out-of-bounds
                if (tempY < 0 || tempY >= i32_height) break;
                if (m_sz_gameElement[targetGameElement.i32_idX, tempY].enum_gridType == ENUM_GRID_TYPE.CLOSE) break;

                if (m_sz_gameElement[targetGameElement.i32_idX, tempY].enum_gameElementType == targetGameElement.enum_gameElementType) {
                    list_vert.Add(m_sz_gameElement[targetGameElement.i32_idX, tempY]);
                } else break; //break-out-loop-if-found-different-gameelement
            }
        }

        //add-vertical-matches-to-matches
        if (list_vert.Count < 3) list_vert = null;

        //add-to-list-matches
        if (list_horz != null) list_matches.AddRange(list_horz);
        if (list_vert != null) list_matches.AddRange(list_vert);

        //return-result
        if (list_matches.Count >= 3) return list_matches; //early-exit-and-return-results        
        return null; //return-nothing-if-reach-this-point
    }

    public void ClearMatches(List<GameElement> matchList) {
        if (matchList == null) return; //safe-check

        foreach (GameElement item in matchList) {
            item.SetGameElementType(ENUM_GAMEELEMENT_TYPE.EMPTY);
            ManagerCurrency.Instance.IncreaseCurrency(ENUM_CURRENCY_TYPE.HIGH_SCORE, ManagerCurrencySettings.K_VALUE_HIGHSCORE);
        }
    }

    public void ClearMatches(GameElement targetGameElement) {
        List<GameElement> tempListMatches = GetListMatches(targetGameElement);

        if (tempListMatches == null) return; //safe-check

        AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE.MATCH_COMPLETE);

        foreach (GameElement item in tempListMatches) {
            item.SetGameElementType(ENUM_GAMEELEMENT_TYPE.EMPTY);
            if (isDoneInitBoard == false) continue;
            ManagerCurrency.Instance.IncreaseCurrency(ENUM_CURRENCY_TYPE.HIGH_SCORE, ManagerCurrencySettings.K_VALUE_HIGHSCORE);
        }
    }

    public System.Collections.IEnumerator GameBoardMoveDown() {

        IsInProgress = true; //IMPORTANT

        //Move downward on Y Axis
        for (int col = 0; col < i32_height; col++) {

            int colAbove = col + 1;
            if (IsWithinHeight(colAbove) == false) break;

            for (int row = 0; row < i32_width; row++) {

                GameElement gameElement = m_sz_gameElement[row, col];

                if (gameElement.enum_gridType == ENUM_GRID_TYPE.CLOSE) continue; //skip-this-grid-type

                GameElement gameElementAbove = m_sz_gameElement[row, colAbove];

                //switch-below-game-element-to-current-game-element
                if (gameElement.enum_gameElementType == ENUM_GAMEELEMENT_TYPE.EMPTY
                    && gameElementAbove.enum_gameElementType != ENUM_GAMEELEMENT_TYPE.EMPTY) {
                    yield return new WaitForSeconds(Match3Settings.K_GAME_WAIT_TIME);

                    AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE.MOVE_DOWN);

                    gameElement.SetGameElementType(gameElementAbove.enum_gameElementType);
                    gameElementAbove.SetGameElementType(ENUM_GAMEELEMENT_TYPE.EMPTY);
                }
            }
        }

        if (IsEmptyAtWrongPlace()) yield return StartCoroutine(GameBoardMoveDown());
        yield return StartCoroutine(GameBoardFillRandom());
    }

    public bool IsEmptyAtWrongPlace() {

        for (int col = 0; col < i32_height; col++) {

            int colAbove = col + 1;
            if (IsWithinHeight(colAbove) == false) break;

            for (int row = 0; row < i32_width; row++) {

                if (m_sz_gameElement[row, col].enum_gridType == ENUM_GRID_TYPE.CLOSE) continue; //break-out-loop                                               

                if (m_sz_gameElement[row, col].enum_gameElementType == ENUM_GAMEELEMENT_TYPE.EMPTY
                    && m_sz_gameElement[row, colAbove].enum_gameElementType != ENUM_GAMEELEMENT_TYPE.EMPTY) {
                    return true;
                }
            }
        }

        return false;
    }

    public System.Collections.IEnumerator GameBoardFillRandom() {
        //random-game-element-on-empty-game-element
        for (int col = 0; col < i32_height; col++) {
            for (int row = 0; row < i32_width; row++) {

                if (m_sz_gameElement[row, col].enum_gridType == ENUM_GRID_TYPE.OPEN
                    && m_sz_gameElement[row, col].enum_gameElementType == ENUM_GAMEELEMENT_TYPE.EMPTY) {

                    yield return new WaitForSeconds(Match3Settings.K_GAME_WAIT_TIME);
                    AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE.MOVE_DOWN);
                    int randomID = Random.Range(1, m_database.m_sz_gameElementSprites.Length);
                    m_sz_gameElement[row, col].SetGameElementType((ENUM_GAMEELEMENT_TYPE)randomID);

                    if (GetListMatches(m_sz_gameElement[row, col]) != null) {
                        ClearMatches(m_sz_gameElement[row, col]);
                        yield return StartCoroutine(GameBoardMoveDown()); //exit-goto-this-function
                    }

                }
            }
        }

        //destroy-any-matches-that-was-created-from-randomise-above
        for (int col = 0; col < i32_height; col++) {
            for (int row = 0; row < i32_width; row++) {

                if (m_sz_gameElement[row, col].enum_gridType == ENUM_GRID_TYPE.OPEN
                    && m_sz_gameElement[row, col].enum_gameElementType != ENUM_GAMEELEMENT_TYPE.EMPTY) {

                    if (GetListMatches(m_sz_gameElement[row, col]) != null) {
                        ClearMatches(m_sz_gameElement[row, col]);
                        yield return StartCoroutine(GameBoardMoveDown()); //exit-goto-this-function
                    }

                }
            }
        }

        IsInProgress = false; //IMPORTANT
        if (isDoneInitBoard == false) isDoneInitBoard = true; //board-successfully-init
        yield return null; //exit-out
    }

    private bool IsTwoGameElementClose() {
        int x = m_currentGameElement.i32_idX - m_targetGameElement.i32_idX;
        int y = m_currentGameElement.i32_idY - m_targetGameElement.i32_idY;

        if (Mathf.Abs(x) <= 1 && Mathf.Abs(y) <= 1) return true;
        else { ResetGameManager(); return false; }
    }

    private bool IsWithinWidth(int input) {
        if (input >= 0 && input < i32_width) return true;
        else return false;
    }

    private bool IsWithinHeight(int input) {
        if (input >= 0 && input < i32_height) return true;
        else return false;
    }

    public void OnClickGameElement(GameElement gameElement) {
        if (IsInProgress) return; //safe-check
        if (m_currentGameElement != null) return;
        if (gameElement.enum_gridType == ENUM_GRID_TYPE.CLOSE) return;

        AudioManager.Instance.PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE.SELECT);
        m_currentGameElement = gameElement;
    }

    public void OnDragGameElementToPosition(GameElement gameElement) {
        if (IsInProgress) return;
        if (m_currentGameElement == null) return;
        if (gameElement.enum_gridType == ENUM_GRID_TYPE.CLOSE) return;
        
        m_targetGameElement = gameElement;
    }

    public void OnReleaseGameElement() {
        if (IsInProgress) return; //safe-check
        if (m_currentGameElement == null || m_targetGameElement == null) return;
        if (IsTwoGameElementClose() == false) return;
        if (m_currentGameElement == m_targetGameElement
            || m_currentGameElement.enum_gameElementType == m_targetGameElement.enum_gameElementType) {
            ResetGameManager(); return;
        }        

        //switch-gameelements        
        ENUM_GAMEELEMENT_TYPE tempGameElementType = m_currentGameElement.enum_gameElementType;
        m_currentGameElement.SetGameElementType(m_targetGameElement.enum_gameElementType);
        m_targetGameElement.SetGameElementType(tempGameElementType);

        //switch-back-if-no-matches-on-two-game-element-switch
        if (GetListMatches(m_currentGameElement) == null && GetListMatches(m_targetGameElement) == null) {            
            m_targetGameElement.SetGameElementType(m_currentGameElement.enum_gameElementType);
            m_currentGameElement.SetGameElementType(tempGameElementType);
            ResetGameManager(); return;
        }

        //validate-game-board
        ClearMatches(m_targetGameElement);
        ClearMatches(m_currentGameElement);

        //move-game-board-down
        StartCoroutine(GameBoardMoveDown());

        //add-counter
        ManagerCurrency.Instance.IncreaseCurrency(ENUM_CURRENCY_TYPE.MOVE, ManagerCurrencySettings.K_VALUE_MOVE);

        ResetGameManager(); //reset
    }

    private void ResetGameManager() {
        m_currentGameElement = null;
        m_targetGameElement = null;
    }
}
