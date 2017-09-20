using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverEffect : MonoBehaviour {

    bool pointerin = false;
    public AnimationClip rotateButton;
    public AnimationClip rotateButtonNoLoop;

    public void PointerEnter()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play(rotateButton.name);
        }
    }

    public void PointerExit()
    {
        pointerin = false;
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play(rotateButtonNoLoop.name);
        }
    }

    private IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
}
