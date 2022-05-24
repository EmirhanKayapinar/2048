using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2048 : MonoBehaviour
{
    public Cell2048 right;
    public Cell2048 left;
    public Cell2048 up;
    public Cell2048 down;

    public Fill2048 _fill;
    private void OnEnable()
    {
        GameController._slide += OnSlide;
    }

    private void OnSlide(string whatWasSent)
    {
        CellCheck();
        Debug.Log(whatWasSent);

        if (whatWasSent == "w")
        {
            if (up != null)
            
                return;
            
            Cell2048 currentCell = this;
            SlideUp(currentCell);
        }

        if (whatWasSent == "d")
        {
            if (right != null)

                return;

            Cell2048 currentCell = this;
            SlideRight(currentCell);
        }

        if (whatWasSent == "s")
        {
            if (down != null)

                return;

            Cell2048 currentCell = this;
            SlideDown(currentCell);
        }

        if (whatWasSent == "a")
        {
            if (left != null)

                return;

            Cell2048 currentCell = this;
            SlideLeft(currentCell);
        }

        GameController.ticker++;

        if (GameController.ticker == 4)
        {
            GameController.instance.SpawnFill();        }
    }

    void SlideUp(Cell2048 currentCell)
    {
        if (currentCell.down == null)
        {
            return;
        }
        if (currentCell._fill != null )
        {
            Cell2048 nextCell = currentCell.down;
            while (nextCell.down != null && nextCell._fill ==null)
            {
                nextCell = nextCell.down;
            }

            if (nextCell._fill != null)
            {
                if(currentCell._fill.value == nextCell._fill.value)
                {
                    nextCell._fill.Double();
                    nextCell._fill.transform.parent = currentCell.transform;
                    currentCell._fill = nextCell._fill;
                    nextCell._fill = null;
                }

                else if(currentCell.down._fill != nextCell._fill)
                {
                    Debug.Log("!doubled");
                    nextCell._fill.transform.parent = currentCell.down.transform;
                    currentCell.down._fill = nextCell._fill;
                    nextCell._fill = null;
                }
            }
        }

        else
        {
            Cell2048 nextCell = currentCell.down;
            while (nextCell.down != null && nextCell._fill == null)
            {
                nextCell = nextCell.down;
            }

            if (nextCell._fill != null)
            {
                nextCell._fill.transform.parent = currentCell.transform;
                currentCell._fill = nextCell._fill;
                nextCell._fill = null;
                SlideUp(currentCell);
                Debug.Log("Slide to empty");
            }
        }
        
        
        
        
        Debug.Log(currentCell.gameObject);
        if (currentCell.down == null)
            return;

        SlideUp(currentCell.down);
        
    }

    void SlideRight(Cell2048 currentCell)
    {
        if (currentCell.left == null)
        {
            return;
        }
        if (currentCell._fill != null)
        {
            Cell2048 nextCell = currentCell.left;
            while (nextCell.left != null && nextCell._fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell._fill != null)
            {
                if (currentCell._fill.value == nextCell._fill.value)
                {
                    nextCell._fill.Double();
                    nextCell._fill.transform.parent = currentCell.transform;
                    currentCell._fill = nextCell._fill;
                    nextCell._fill = null;
                }

                else if (currentCell.left._fill != nextCell._fill)
                {
                    Debug.Log("!doubled");
                    nextCell._fill.transform.parent = currentCell.left.transform;
                    currentCell.left._fill = nextCell._fill;
                    nextCell._fill = null;
                }
            }
        }

        else
        {
            Cell2048 nextCell = currentCell.left;
            while (nextCell.left != null && nextCell._fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell._fill != null)
            {
                nextCell._fill.transform.parent = currentCell.transform;
                currentCell._fill = nextCell._fill;
                nextCell._fill = null;
                SlideRight(currentCell);
                Debug.Log("Slide to empty");
            }
        }




        Debug.Log(currentCell.gameObject);
        if (currentCell.left == null)
            return;

        SlideRight(currentCell.left);

    }

    void SlideDown(Cell2048 currentCell)
    {
        if (currentCell.up == null)
        {
            return;
        }
        if (currentCell._fill != null)
        {
            Cell2048 nextCell = currentCell.up;
            while (nextCell.up != null && nextCell._fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell._fill != null)
            {
                if (currentCell._fill.value == nextCell._fill.value)
                {
                    nextCell._fill.Double();
                    nextCell._fill.transform.parent = currentCell.transform;
                    currentCell._fill = nextCell._fill;
                    nextCell._fill = null;
                }

                else if (currentCell.up._fill != nextCell._fill)
                {
                    Debug.Log("!doubled");
                    nextCell._fill.transform.parent = currentCell.up.transform;
                    currentCell.up._fill = nextCell._fill;
                    nextCell._fill = null;
                }
            }
        }

        else
        {
            Cell2048 nextCell = currentCell.up;
            while (nextCell.up != null && nextCell._fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell._fill != null)
            {
                nextCell._fill.transform.parent = currentCell.transform;
                currentCell._fill = nextCell._fill;
                nextCell._fill = null;
                SlideDown(currentCell);
                Debug.Log("Slide to empty");
            }
        }




        Debug.Log(currentCell.gameObject);
        if (currentCell.up == null)
            return;

        SlideDown(currentCell.up);

    }
    void SlideLeft(Cell2048 currentCell)
    {
        if (currentCell.right == null)
        {
            return;
        }
        if (currentCell._fill != null)
        {
            Cell2048 nextCell = currentCell.right;
            while (nextCell.right != null && nextCell._fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell._fill != null)
            {
                if (currentCell._fill.value == nextCell._fill.value)
                {
                    nextCell._fill.Double();
                    nextCell._fill.transform.parent = currentCell.transform;
                    currentCell._fill = nextCell._fill;
                    nextCell._fill = null;
                }

                else if (currentCell.right._fill != nextCell._fill)
                {
                    Debug.Log("!doubled");
                    nextCell._fill.transform.parent = currentCell.right.transform;
                    currentCell.right._fill = nextCell._fill;
                    nextCell._fill = null;
                }
            }
        }

        else
        {
            Cell2048 nextCell = currentCell.right;
            while (nextCell.right != null && nextCell._fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell._fill != null)
            {
                nextCell._fill.transform.parent = currentCell.transform;
                currentCell._fill = nextCell._fill;
                nextCell._fill = null;
                SlideLeft(currentCell);
                Debug.Log("Slide to empty");
            }
        }




        Debug.Log(currentCell.gameObject);
        if (currentCell.right == null)
            return;

        SlideLeft(currentCell.right);

    }
    private void OnDisable()
    {
        GameController._slide -= OnSlide;
    }

    void CellCheck()
    {
        if (_fill == null)
        {
            return;
        }

        if (right != null)
        {
            if (right._fill==null)
            {
                return;
            }

            if (right._fill.value == _fill.value)
            {
                return;
            }
        }


        if (up != null)
        {
            if (up._fill == null)
            {
                return;
            }

            if (up._fill.value == _fill.value)
            {
                return;
            }
        }



        if (down != null)
        {
            if (down._fill == null)
            {
                return;
            }

            if (down._fill.value == _fill.value)
            {
                return;
            }
        }



        if (left != null)
        {
            if (left._fill == null)
            {
                return;
            }

            if (left._fill.value == _fill.value)
            {
                return;
            }
        }

        GameController.instance.GameOverCheck();
    }
}
