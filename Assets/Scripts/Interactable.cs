
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    private float maxVisibleTime = 4f;// dodaæ zmienn¹ max dla Panelu Large ale wartoœæ wiêksza ni¿ 4 bo to jest za krótki czas do przeczytania
    private float maxLargePanelVisibleTime = 5f;
    private float timeSinceInfoVisible = 0f;
    private bool isIterationTextVisible = false;

    public UIManager manager;
    public GameObject information;
    private bool ChairFound = false;
    private bool ComputerFound = false;
    private bool Computer2Found = false;
    private bool CressFound = false;
    private bool NoteFound = false;
    private bool SampleFound = false;
    private bool LabEquipFound = false;
    private bool CodeFound = false;
    private bool ToiletWFound = false;
    private bool ToiletMFound = false;
    private bool KeyCard2Found = false;
    public bool KeyCard3Found = false;
    private bool KeyCard4Found = false;
    private bool KeyCardZFound = false;
    private bool doorRedFound = false;
    private bool doorYellowFound = false;
    private bool doorOrangeFound = false;
    private bool bulletFound = false;// DOKONCYC - 
    private bool boxMoved = false;
    public bool greenBoxMoved = false;
    public bool radioFound = false;
    private bool largeTextVisible;
    private float timeSinceInfoLargeVisible;
    public GameObject endGameScreen;
    public GameObject storyTriger;
    public GameObject storyPanel;
    public float StartGame;
    private AudioManager audioManager;


    //public TMP_Tex thinks;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void StartGameButton()
    {
        storyPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
     //public float OpenGame()
     //{
       // Application.PlayGame();
    // }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
            endGameScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }


        timeSinceInfoVisible += Time.deltaTime;
        // dla large jak linijka wy¿ej!
        timeSinceInfoLargeVisible += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 1.98f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
                if (collider is not BoxCollider)
                {
                    if (collider.gameObject.tag == "Chair")
                    {
                        if (!isIterationTextVisible)// && !ChairFound)
                        {

                            manager.SetBottomText("PRZEWRÓCONE KRZES£O"); //Overturned chair"
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            //ChairFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Computer")
                    {
                        if (!isIterationTextVisible && !ComputerFound)
                        {
                            manager.SetBottomText("");
                            manager.SetMailPanetVisibility(true);
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            ComputerFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Computer2")
                    {
                        if (!isIterationTextVisible) // && !Computer2Found)
                        {
                            manager.SetBottomText("ZNISZCZONY KOMPUTER"); //Broken Computer
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            //Computer2Found = true;
                        }
                    }
                    if (collider.gameObject.tag == "Cress")
                    {
                        if (!isIterationTextVisible)//&& !CressFound)
                        {
                            manager.SetBottomText("SKRZYNKA Z ROŒLIN¥");//Box of cress
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            //CressFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Note")
                    {
                        if (!isIterationTextVisible && !NoteFound)
                        {
                            manager.SetBottomText("HIPOTEZA: CZY ROŒLINA MO¯E WYROSN¥Æ NA PRÓBCE ZIEMI?   WNIOSEK: ROŒLINA, MO¯E WYROSN¥Æ NA PRÓBCE GLEBY");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            NoteFound = true;
                        }
                    } // Tutaj daæ dzialanie w formie informacji na ekranie jak przy Mailu
                    if (collider.gameObject.tag == "Sample")
                    {
                        if (!isIterationTextVisible && !SampleFound)
                        {
                            // zamieniæ poni¿szy: SetBottomText na: ShowLargePanel (ale dopiero po podpiêciu w Unity odpowiedniego panelu i tekstu)

                            manager.ShowLargePanel("INFORMACJA O OBIEKCIE:PRÓBKA NIEZIDENTYFIKOWANEGO BIOLOGICZNIE MATERIA£U PODOBNEGO WYGL¥DEM DO KRYSZTA£U");
                            largeTextVisible = true; // largeTextVivible
                            timeSinceInfoLargeVisible = 0f; // timeSinceInfoLargeVisible 
                            SampleFound = true;
                        }
                    }   // Tutaj daæ dzialanie w formie informacji na ekranie jak przy Mailu
                    if (collider.gameObject.tag == "LabEquip")
                    {
                        if (!isIterationTextVisible) // && !LabEquipFound)
                        {
                            manager.SetBottomText("ZNISZCZONY SPRZÊT LABORATORYJNY");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            // LabEquipFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "Code")
                    {
                        if (!isIterationTextVisible && !CodeFound && boxMoved)
                        {
                            manager.SetBottomText("KOD: 4190");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            CodeFound = true;
                            // Zabezpieczenie by nie poznac / zebrac kodu puki nie przesunie sie pudelka
                            // Zrobic ze kod 'Code: 4190' jest pokazany na gorze ekranu do czasu skozystania z kodu
                        }
                    }
                    if (collider.gameObject.tag == "ToiletW")
                    {
                        if (!isIterationTextVisible && !ToiletWFound)
                        {
                            manager.SetBottomText("DAMSKA TOALETA");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            ToiletWFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "ToiletM")
                    {
                        if (!isIterationTextVisible && !ToiletMFound)
                        {
                            manager.SetBottomText("MÊSKA TOALETA");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            ToiletMFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "KeyCard2")
                    {
                        if (!isIterationTextVisible && !KeyCard2Found)
                        {
                            manager.SetBottomText("KARTA MAGNETYCZNA DO POKOJU LABORATORYJNEGO NR.2");
                            audioManager.PlaySFX(audioManager.collectible);
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            KeyCard2Found = true;
                            GameObject key = GameObject.Find("KeyCard2");
                            if (key != null)
                            {
                                Destroy(key);
                            }
                        }
                    }
                    if (collider.gameObject.tag == "KeyCard3")
                    {
                        if (!isIterationTextVisible && !KeyCard3Found)
                        {
                            manager.SetBottomText("KARTA MAGNETYCZNA DO POKOJU LABORATORYJNEGO NR.3");
                            audioManager.PlaySFX(audioManager.collectible);
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            KeyCard3Found = true;
                            GameObject key = GameObject.Find("KeyCard3");
                            if (key != null)
                            {
                                Destroy(key);
                            }
                        }
                    }
                    if (collider.gameObject.tag == "KeyCard4")
                    {
                        if (!isIterationTextVisible && !KeyCard4Found && greenBoxMoved)
                        {
                            manager.SetBottomText("KARTA MAGNETYCZNA DO SERWEROWNI");
                            audioManager.PlaySFX(audioManager.collectible);
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            KeyCard4Found = true;
                            GameObject key = GameObject.Find("KeyCard4");
                            if (key != null)
                            {
                                Destroy(key);
                            }
                        }
                    }
                    if (collider.gameObject.tag == "KeyCardZ")
                    {
                        if (!isIterationTextVisible && !KeyCardZFound)
                        {
                            manager.SetBottomText("KARTA MAGNETYCZNA DO 2 PIÊTRA - USZKODZONA ");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            KeyCardZFound = true;
                        }
                    }
                    if (collider.gameObject.tag == "DoorRed") // Czerwone, Zulte, Pomaranczowe, Damska i Menska toaleta - zrobione
                    {
                        if (KeyCard2Found)
                        {
                            if (!isIterationTextVisible && !doorRedFound)
                            {
                                manager.SetBottomText("POKÓJ LABORATORYJNY NR.2 - OTWARTE!");
                                audioManager.PlaySFX(audioManager.doorSound);
                                isIterationTextVisible = true;
                                timeSinceInfoVisible = 0f;
                                doorRedFound = true;
                                GameObject door = GameObject.Find("Door2_Red");
                                if (door != null)
                                {
                                    Destroy(door); // Czarne - do zrobienia
                                }
                            }
                        }
                        else
                        {
                            if (!isIterationTextVisible)
                            {
                                manager.SetBottomText("NIE MASZ KLUCZA DO TYCH DRZWI!");
                                isIterationTextVisible = true;
                                timeSinceInfoVisible = 0f;
                            }
                        }
                    }
                    if (collider.gameObject.tag == "DoorYellow")
                    {
                        if (KeyCard3Found)
                        {
                            if (!isIterationTextVisible && !doorYellowFound)
                            {
                                manager.SetBottomText("POKÓJ LABORATORYJNY NR.3 - OTWARTE!");
                                audioManager.PlaySFX(audioManager.doorSound);
                                isIterationTextVisible = true;
                                timeSinceInfoVisible = 0f;
                                doorYellowFound = true;
                                GameObject door = GameObject.Find("DoorYellow");
                                if (door != null)
                                {
                                    Destroy(door);
                                }
                            }
                        }
                        else
                        {
                            if (!isIterationTextVisible)
                            {
                                manager.SetBottomText("NIE MASZ KLUCZA DO TYCH DRZWI!");
                                isIterationTextVisible = true;
                                timeSinceInfoVisible = 0f;
                            }
                        }
                    }
                    if (collider.gameObject.tag == "DoorOrange")
                    {
                        if (KeyCard4Found)
                        {
                            if (!isIterationTextVisible && !doorOrangeFound)
                            {
                                manager.SetBottomText("SERWEROWNIA - OTWARTE!");
                                audioManager.PlaySFX(audioManager.doorSound);
                                isIterationTextVisible = true;
                                timeSinceInfoVisible = 0f;
                                doorOrangeFound = true;
                                GameObject door = GameObject.Find("Door4_Orange");
                                if (door != null)
                                {
                                    Destroy(door);
                                }
                            }
                        }
                        else
                        {
                            if (!isIterationTextVisible)
                            {
                                manager.SetBottomText("NIE MASZ KLUCZA DO TYCH DRZWI!");
                                isIterationTextVisible = true;
                                timeSinceInfoVisible = 0f;
                            }
                        }
                    }
                    //if (collider.gameObject.tag == "DO_ZMIANY!!!")
                    //{
                    //    if (KeyCard4Found)
                    //    {
                    //        if (!isIterationTextVisible && !doorOrangeFound)
                    //        {
                    //            manager.SetBottomText("DOOR ORANGE OPENED!");
                    //            isIterationTextVisible = true;
                    //            timeSinceInfoVisible = 0f;
                    //            doorOrangeFound = true;
                    //            GameObject door = GameObject.Find("Door4_Orange");
                    //            if (door != null)
                    //            {
                    //                Destroy(door);
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (!isIterationTextVisible)
                    //        {
                    //            manager.SetBottomText("NIE MASZ KLUCZA DO TYCH DRZWI!");//You haven't key to this door!"
                    //            isIterationTextVisible = true;
                    //            timeSinceInfoVisible = 0f;
                    //        }
                    //    }
                    //}
                    if (collider.gameObject.tag == "bullet")
                    {
                        if (!isIterationTextVisible && !bulletFound)
                        {
                            manager.SetBottomText("DZIURY PO KULACH");
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            bulletFound = true;
                        }
                    }

                    //if (collider.gameObject.tag == "storyTriger")
                    //{
                    //    if (!isIterationTextVisible && !storyTriger)
                    //    {
                    //        manager.SetStoryPanelVisibility(true);
                    //        isIterationTextVisible = true;
                    //        timeSinceInfoVisible = 0f;
                    //        //storyTriger = true;
                    //    }
                    //}
                    if (collider.gameObject.tag == "radio")
                    {
                       if (!isIterationTextVisible && !radioFound)
                        {
                            manager.SetBottomText("STARE RADIO");
                            audioManager.PlaySFX(audioManager.boomBox);
                            isIterationTextVisible = true;
                            timeSinceInfoVisible = 0f;
                            bulletFound = true;
                        }
                    }
                }
            }
        }

        if (timeSinceInfoVisible >= maxVisibleTime)
        {
            if (isIterationTextVisible)
            {
                manager.HideBottomText();
                isIterationTextVisible = false;
            }
            timeSinceInfoVisible = 0f;
        }

        // tu obs³uga z nowymi zmiennymi dla Large! (jak powy¿szy if)
        if (timeSinceInfoLargeVisible >= maxLargePanelVisibleTime)
        {
            if (largeTextVisible)
            {
                manager.HideLargeText();
                largeTextVisible = false;
            }
            timeSinceInfoLargeVisible = 0f;
        }
    }

    public void EndGameButton()
    {
        Application.Quit();
    }

    public void ContinueGameButton()
    {
        endGameScreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void showLastInfo()
    {
        manager.SetBottomText("POTRZEBUJESZ KLUCZA NR 3");
        timeSinceInfoVisible = 0f;
        isIterationTextVisible = true;
    }


}
