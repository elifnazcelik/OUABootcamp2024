using UnityEngine;

public class TrashItem : MonoBehaviour
{
    public TrashType trashType; // ��p t�r�

    // Collider'a giri� yap�ld���nda tetiklenen fonksiyon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TrashBin trashBin = collision.GetComponent<TrashBin>();
        if (trashBin != null)
        {
            if (trashBin.acceptedTrashType == trashType)
            {
                // Do�ru ��p kutusuna at�ld�, nesneyi yok et
                Destroy(gameObject);

                // Sayac� g�ncelle
                trashBin.IncreaseCounter();
            }
            else
            {
                // Yanl�� ��p kutusuna at�ld�, uyar� mesaj� g�ster
                trashBin.ShowWarning("Bu at�k bu kutuya uygun de�il");
            }
        }
    }
}
