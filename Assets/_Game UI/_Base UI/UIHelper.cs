using UnityEngine;

namespace GAME
{
    public class UIHelper : MonoBehaviour
    {
        public static void HideCellOfList(GameObject cell)
        {
            Transform list = cell.transform.parent;
            cell.SetActive(false);
            cell.transform.SetParent(list.parent);
        }
    }

}

