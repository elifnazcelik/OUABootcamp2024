using UnityEngine;

public class TrashItem : MonoBehaviour
{
    public TrashType trashType; // Çöp türü

    // Collider'a giriþ yapýldýðýnda tetiklenen fonksiyon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TrashBin trashBin = collision.GetComponent<TrashBin>();
        if (trashBin != null)
        {
            if (trashBin.acceptedTrashType == trashType)
            {
                // Doðru çöp kutusuna atýldý, nesneyi yok et
                Destroy(gameObject);

                // Sayacý güncelle
                trashBin.IncreaseCounter();
            }
            else
            {
                // Yanlýþ çöp kutusuna atýldý, uyarý mesajý göster
                trashBin.ShowWarning("Bu atýk bu kutuya uygun deðil");
            }
        }
    }
}
