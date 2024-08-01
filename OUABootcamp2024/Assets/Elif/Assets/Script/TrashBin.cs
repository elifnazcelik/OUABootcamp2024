using UnityEngine;
using UnityEngine.UI;

public class TrashBin : MonoBehaviour
{
    public TrashType acceptedTrashType; // Bu ��p kutusunun kabul etti�i ��p t�r�
    public Text warningText; // Uyar� mesaj�n� g�stermek i�in UI Text
    public Text counterText; // ��p kutusundaki ��p say�s�n� g�stermek i�in UI Text

    private int trashCount = 0; // ��p say�s�n� takip etmek i�in de�i�ken

    private void Start()
    {
        // �lk ba�ta saya� ve uyar� metinlerini temizle
        UpdateCounterText();
        ClearWarning();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��p nesnesinin TrashItem bile�enini al
        TrashItem trash = other.GetComponent<TrashItem>();

        // E�er ��p nesnesi varsa ve ��p t�r� bu kutunun kabul etti�i t�r ile e�le�iyorsa
        if (trash != null && trash.trashType == acceptedTrashType)
        {
            // ��p nesnesini yok et
            Destroy(other.gameObject);
            // ��p say�s�n� art�r
            trashCount++;
            // Saya� metnini g�ncelle
            UpdateCounterText();
            // Uyar� mesaj�n� temizle
            ClearWarning();
        }
        else
        {
            // Uyar� mesaj�n� g�ster
            ShowWarning("Bu at�k bu kutuya uygun de�il");
        }
    }

    public void IncreaseCounter()
    {
        trashCount++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        if (counterText != null)
        {
            counterText.text = "Count: " + trashCount.ToString();
        }
    }

    public void ShowWarning(string message)
    {
        if (warningText != null)
        {
            warningText.text = message;
        }
    }

    private void ClearWarning()
    {
        if (warningText != null)
        {
            warningText.text = "";
        }
    }
}
