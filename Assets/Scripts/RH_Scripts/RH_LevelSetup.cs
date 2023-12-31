using Assets.Scripts.RH_Scripts.Classes;
using Assets.Scripts.UI;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class RH_LevelSetup : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Game items")]
    public BoxCollider Key;
    public DialogueSystem DialogueSystem;
    public KeyPadInteraction KeyPad;
    public Transform BookCameraFocus;
    public LaptopInteraction Laptop;
    public Animator Lightning;

    [Header("Animations")]
    public AnimationClip LightningActivated;

    [Header("Director")]
    public PlayableDirector Director;

    [Header("Timeline cutscenes")]
    public TimelineAsset BookMissing;
    public TimelineAsset BooksDelivered;
    public TimelineAsset DoorOpen;
    public TimelineAsset Intro;
    public TimelineAsset WrongBook;

    [Header("UIManagers")]
    public GameOverManager gameOver;
    public CountdownManager Countdown;


    [Header("Game settings")]
    public int BooksNeeded = 6;
    
    private int booksInventory = 0;
    private int _booksDelivered = 0;

    private Book bookEquipped;

    public int BooksInventory { get => booksInventory; set => booksInventory = value; }
    private DimensionalShift shift;

    void Start()
    {
        shift = gameObject.GetComponent<DimensionalShift>();
        shift.isDimensionalShiftEnabled = false;
        shift.OnCameraChanged += DimensionalShift_OnCameraChanged;

        Director.Play(Intro);
    }

    private void DimensionalShift_OnCameraChanged(bool cameraIs3D)
    {
        GameObject[] remove = GameObject.FindGameObjectsWithTag("RemoveIn2D");
        if (!cameraIs3D)
        {
            foreach (GameObject obj in remove)
            {
                obj.GetComponent<Renderer>().enabled = false;
            }
            if (Key != null)
                Key.enabled = true;
        } else
        {
            foreach (GameObject obj in remove)
            {
                obj.GetComponent<Renderer>().enabled = true;
            }
            if (Key != null)
                Key.enabled = false;
        }
    }
    /// <summary>
    /// Should be fired when a book gets delivered.
    /// </summary>
    /// <param name="book">The book that is being interacted with.</param>
    /// <returns>If the book can be delivered or not.</returns>
    private bool MissingDone = false;
    public bool BookDelivered(BookInteraction book)
    {
        //Once we delivered 5 books, we start the missingbook timeline scene.
        //Then once the timeline scene has been started, we use the laptop to buy a recycled notebook
        //If we have delivered the recycled notebook we'll start the BooksDelivered cutscene.
        //If we deliver the wrong book, then we start the WrongBook cutscene and we don't add a book delivered.

        if (booksInventory > 0)
        {
            if (bookEquipped.RecycledBook)
            {
                booksInventory--;
                _booksDelivered++;
                book.HasDelivered = true;
                if (MissingDone)
                {
                    Laptop.AllowInteraction = false;
                    Lightning.Play(LightningActivated.name);
                    Director.Play(BooksDelivered);
                }
            } else
            {
                booksInventory--;
                Director.Play(WrongBook);
                return false;
            }  
        } else
        {
            return false;
        }

        if (_booksDelivered >= BooksNeeded && !MissingDone)
        {
            PlayMissingBookCutscene();
        }
        return true;
    }
    private Coroutine GameOverCouritine;
    private void PlayMissingBookCutscene()
    {
        if (GameOverCouritine != null)
            StopCoroutine(GameOverCouritine);
        Countdown.Hide();

        MissingDone = true;
        BookInteraction[] books = GameObject.FindObjectsByType<BookInteraction>(FindObjectsSortMode.None);
        Transform bookTransform = findBookMissing(books).transform;
        BookCameraFocus.transform.position = bookTransform.position;
        CinemachineVirtualCamera[] cameras = BookCameraFocus.GetComponentsInChildren<CinemachineVirtualCamera>();
        foreach (CinemachineVirtualCamera camera in cameras)
        {
            camera.LookAt = bookTransform;
        }
        Director.Play(BookMissing);
        Laptop.AllowInteraction = true;
    }

    private BookInteraction findBookMissing(BookInteraction[] books)
    {
        foreach (BookInteraction book in books)
        {
            if (!book.HasDelivered)
                return book;
        }
        return null;
    }
    public void GiveBook(Book book)
    {
        BooksInventory++;
        bookEquipped = book; 
    }

    public void KeyCollected()
    {
        KeyPad.AllowInteraction = true;
    }
    public void EnablePower()
    {
        shift.isDimensionalShiftEnabled = true;
    }
    // Update is called once per frame
    public int CountdownSeconds;
    public void StartGame()
    {
        GameOverCouritine = StartCoroutine(CountDown(CountdownSeconds));
    }
    public IEnumerator CountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Countdown.ShowCounter(i);
            yield return new WaitForSeconds(1f);
        }
        //If we haven't delivered the books slow down time and show the game over UI.
        Time.timeScale = 1F;
        do
        {
            yield return new WaitForSeconds(0.1F);
            Time.timeScale -= 0.1F;
        } while (Time.timeScale > 0.1);
        Time.timeScale = 0F;
        gameOver.ShowGameOverText("Try to be faster next time!");
        Time.timeScale = 1F;
    }
    void Update()
    {
    }
}
