using UnityEngine;
using UnityEngine.UI;

public class TrashBin : MonoBehaviour
{
    public TrashType acceptedTrashType; // Bu çöp kutusunun kabul ettiði çöp türü
    public Text warningText; // Uyarý mesajýný göstermek için UI Text
    public Text counterText; // Çöp kutusundaki çöp sayýsýný göstermek için UI Text

    private int trashCount = 0; // Çöp sayýsýný takip etmek için deðiþken

    private void Start()
    {
        // Ýlk baþta sayaç ve uyarý metinlerini temizle
        UpdateCounterText();
        ClearWarning();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Çöp nesnesinin TrashItem bileþenini al
        TrashItem trash = other.GetComponent<TrashItem>();

        // Eðer çöp nesnesi varsa ve çöp türü bu kutunun kabul ettiði tür ile eþleþiyorsa
        if (trash != null && trash.trashType == acceptedTrashType)
        {
            // Çöp nesnesini yok et
            Destroy(other.gameObject);
            // Çöp sayýsýný artýr
            trashCount++;
            // Sayaç metnini güncelle
            UpdateCounterText();
            // Uyarý mesajýný temizle
            ClearWarning();
        }
        else
        {
            // Uyarý mesajýný göster
            ShowWarning("Bu atýk bu kutuya uygun deðil");
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
