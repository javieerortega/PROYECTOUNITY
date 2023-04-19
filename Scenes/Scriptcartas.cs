using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scriptcartas : MonoBehaviour
{

    public const int griRows = 2;
    public const int griCols = 4;
    public const float offsetX = 4f;
    public const float offeseY = 6f;

    [SerializeField]
    private carta originalCard;
    [SerializeField]
    private Sprite[] images;

    public int score = 0;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < griCols; i++)
        {
            for (int j = 0; j < griRows; j++)
            {
                carta card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;

                }
                else
                {

                    card = Instantiate(originalCard) as carta;

                }

                int index = j * griCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offeseY * j) + startPos.y;

                card.transform.position = new Vector3(posX, posY, startPos.z);
            }

        }

    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {

            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;

        }

        return newArray;

    }

    private carta _firstReveaLed;
    private carta _sconReveaLed;

    private int _score = 0;

    [SerializeField]
    private TextMesh scoreLabel;

    public bool canReveal
    {
        get { return _sconReveaLed = null; }

    }

    public void CardRevealed(carta card)
    {
        if
        (_firstReveaLed == null)
        {

            _firstReveaLed = card;
        }
        else
        {

            _sconReveaLed = card;
            StartCoroutine(CheckedMatch());

        }
    }
    private IEnumerator CheckedMatch()
    {
        if (_firstReveaLed.id == _sconReveaLed.id)
        {
            _score++;
            scoreLabel.text = "Score: " + _score;

        }
        else
        {

            yield return new WaitForSeconds(0.5f);

            _firstReveaLed.Unreveal();
            _sconReveaLed.Unreveal();
        }

        _firstReveaLed = null;
        _sconReveaLed = null;

    }

    void cardCoparion(List<int> c)
    {

    }

}
