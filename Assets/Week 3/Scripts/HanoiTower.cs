using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    [SerializeField] private int[] pegOne = { 1, 2, 3, 4 };
    [SerializeField] private int[] pegTwo = { 0, 0, 0, 0 };
    [SerializeField] private int[] pegThree = { 0, 0, 0, 0 };

    [SerializeField] private Transform peg1Transform;
    [SerializeField] private Transform peg2Transform;
    [SerializeField] private Transform peg3Transform;

    [SerializeField] private int currentPeg = 1;

    [SerializeField] GameObject youWinLabel;


    [ContextMenu("Move Right")]
    public void MoveRight()
    {
        if (CanMoveRight() == false) return;

        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        if (fromIndex == -1) return;

        int[] toArray = GetPeg(currentPeg + 1);
        int toIndex = GetIndexOfFreeSlot(toArray);

        if (toIndex == -1) return;

        if (CanAddToPeg(fromArray[fromIndex], toArray) == false) return;

        moveNumber(fromArray, fromIndex, toArray, toIndex);

        Transform disc = PopDiscFromCurrentPeg();
        Transform toPeg = GetPegTransform(currentPeg + 1);

        disc.SetParent(toPeg);
    }

    [ContextMenu("Move Left")]
    public void MoveLeft()
    {
        if (CanMoveLeft() == false) return;

        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        if (fromIndex == -1) return;

        int[] toArray = GetPeg(currentPeg - 1);
        int toIndex = GetIndexOfFreeSlot(toArray);

        if (toIndex == -1) return;

        if (CanAddToPeg(fromArray[fromIndex], toArray) == false) return;

        moveNumber(fromArray, fromIndex, toArray, toIndex);

        Transform disc = PopDiscFromCurrentPeg();
        Transform toPeg = GetPegTransform(currentPeg - 1);

        disc.SetParent(toPeg);
    }

    public void IncrementPegNumber()
    {
        currentPeg++;
        if(currentPeg > 3)
        {
            currentPeg = 3;
        }
    }

    public void DecrementPegNumber()
    {
        currentPeg--;
        if (currentPeg < 1)
        {
            currentPeg = 1;
        }
    }

    Transform PopDiscFromCurrentPeg()
    {
        Transform currentPegTransform = GetPegTransform(currentPeg);
        int index = currentPegTransform.childCount - 1;
        Transform disk = currentPegTransform.GetChild(index);
        if (pegThree[0] ==  1)
        {
            if (pegThree[1] == 2)
            {
                if (pegThree[2] == 3)
                {
                    if (pegThree[3] == 4)
                    {
                        youWinLabel.SetActive(true);
                    }
                }
            }
        }
        return disk;
    }

    Transform GetPegTransform(int pegNumber)
    {
        //Alternative way to find our peg
        //GameObject pegObject = GameObject.Find("Peg-" + pegNumber.ToString());
        //return pegObject.transform;

        if (pegNumber == 1) return peg1Transform;

        if (pegNumber == 2) return peg2Transform;

        return peg3Transform;
    }

    void moveNumber(int[] fromArr, int fromIndex, int[] toArr, int toIndex)
    {
        int value = fromArr[fromIndex];
        fromArr[fromIndex] = 0;

        toArr[toIndex] = value;
    }

    bool CanMoveRight()
    {
        return currentPeg < 3;
    }

    bool CanMoveLeft()
    {
        return currentPeg > 1;
    }

    bool CanAddToPeg(int value, int[] peg)
    {
        int topNumberIndex = GetTopNumberIndex(peg);
        if (topNumberIndex == -1) return true;

        int topNumber = peg[topNumberIndex];
        return topNumber > value;
    }

    int[] GetPeg(int pegNumber)
    {
        if (pegNumber == 1) return pegOne;

        if (pegNumber == 2) return pegTwo;

        return pegThree;
    }

    int GetTopNumberIndex(int[] peg)
    {
        for(int i = 0; i < peg.Length; i++)
        {
            if (peg[i] != 0) return i;
        }
        return -1;
    }

    int GetIndexOfFreeSlot(int[] peg)
    {

        for (int i = peg.Length - 1; i >= 0; i--)
        {
            if (peg[i] == 0) return i;
        }
        return -1;
    }
}
