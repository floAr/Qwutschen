using UnityEngine;
using System.Collections;

public enum UIQwutscherLikesDislikes
{
	Nothing,
	Nose,
	Eye,
	Ear
}

public class QwutscherBubbleBehaviour : MonoBehaviour {

	public Sprite LikeNothing;
	public Sprite DislikeNothing;
	public Sprite Nose;
	public Sprite Eye;
	public Sprite Ear;

	public SpriteRenderer P1Like;
	public SpriteRenderer P1Dislike;
	public SpriteRenderer P2Like;
	public SpriteRenderer P2Dislike;

	public UIQwutscherLikesDislikes CurrentP1Like;
	public UIQwutscherLikesDislikes CurrentP1Dislike;
	public UIQwutscherLikesDislikes CurrentP2Like;
	public UIQwutscherLikesDislikes CurrentP2Dislike;
	// Use this for initialization
	void Start () {
		PlayerLikes (UIQwutscherLikesDislikes.Nothing, true);
		PlayerLikes (UIQwutscherLikesDislikes.Nothing, false);
		PlayerDislikes (UIQwutscherLikesDislikes.Nothing, true);
		PlayerDislikes (UIQwutscherLikesDislikes.Nothing, false);
	}

	/// <summary>
	/// Players the likes.
	/// </summary>
	/// <param name="what">What.</param>
	/// <param name="player">If set to <c>true</c> player 1.</param>
	public void PlayerLikes(UIQwutscherLikesDislikes what, bool player)
	{
		if (player) {
			CurrentP1Like = what;
			P1Like.sprite = getSrite(what, true);
		} else {
			CurrentP2Like = what;
			P2Like.sprite = getSrite(what, true);
		}
	}

	/// <summary>
	/// Players the likes.
	/// </summary>
	/// <param name="what">What.</param>
	/// <param name="player">If set to <c>true</c> player 1.</param>
	public void PlayerDislikes(UIQwutscherLikesDislikes what, bool player)
	{
		if (player) {
			CurrentP1Dislike = what;
			P1Dislike.sprite = getSrite(what, false);
		} else {
			CurrentP2Dislike = what;
			P2Dislike.sprite = getSrite(what, false);
		}
	}

	private Sprite getSrite(UIQwutscherLikesDislikes forWhat, bool like)
	{
		switch (forWhat) {
		case UIQwutscherLikesDislikes.Ear:
			return Ear;
		case UIQwutscherLikesDislikes.Eye:
			return Eye;
		case UIQwutscherLikesDislikes.Nose:
			return Nose;
		default:
			return like ? LikeNothing : DislikeNothing;
		}
	}
}
