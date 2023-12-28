using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RH_LevelSetup : MonoBehaviour
{
    // Start is called before the first frame update

    public BoxCollider Key;
    public DialogueSystem DialogueSystem;

    public int BooksNeeded = 6;
    
    private int booksInventory = 0;
    private int _booksDelivered = 0;

    public int BooksInventory { get => booksInventory; set => booksInventory = value; }

    void Start()
    {
        DimensionalShift.isDimensionalShiftEnabled = true;
        DimensionalShift.OnCameraChanged += DimensionalShift_OnCameraChanged;

        
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
    public bool BookDelivered(BookInteraction book) //Replace this with a book interactable class.
    {
        if (book.RecycledBook && booksInventory > 0)
        {
            booksInventory--;
            _booksDelivered++;
        } else if (!book.RecycledBook)
        {

        } else
        {
            return false;
        }
        return true;
        //Once we delivered 6 books, (1 fake one), we start the missingbook timeline scene.
        //Then once the timeline scene has been started, we use the laptop to buy a recycled notebook
        //If we have delivered the recycled notebook we'll start the BooksDelivered cutscene.
        //If we deliver the wrong book, then we start the WrongBook cutscene and we don't add a book delivered.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
