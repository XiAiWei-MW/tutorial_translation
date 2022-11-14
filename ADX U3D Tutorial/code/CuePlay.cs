using UnityEngine;
using CriWare;

public class CuePlay : MonoBehaviour
{
    private CriAtomSource atomSrc;

    void Start() {
        /* CriAtomSource を取得 */
        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");
    }

    public void PlaySound() {
        if (atomSrc != null) {
            atomSrc.Play();
        }
    }

    public void PlayAndStopSound() {
        if (atomSrc != null) {
            /* CriAtomSource の状態を取得 */
            CriAtomSource.Status status = atomSrc.status;
            if ((status == CriAtomSource.Status.Stop) || (status == CriAtomSource.Status.PlayEnd)) {
                /* 停止状態なので再生 */
                atomSrc.Play();
            } else {
                /* 再生中なので停止 */
                atomSrc.Stop();
            }
        }
    }
}
