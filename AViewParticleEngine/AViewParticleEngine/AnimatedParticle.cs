﻿using Android.Graphics.Drawables;

namespace AViewParticleEngine
{
	public class AnimatedParticle : Particle
	{
		private readonly AnimationDrawable mAnimationDrawable;
		private readonly int mTotalTime;

		public AnimatedParticle(AnimationDrawable animationDrawable) {
			mAnimationDrawable = animationDrawable;
			mImage = ((BitmapDrawable) mAnimationDrawable.GetFrame(0)).Bitmap;
			// If it is a repeating animation, calculate the time
			mTotalTime = 0;
			for (int i=0; i<mAnimationDrawable.NumberOfFrames; i++) {
				mTotalTime += mAnimationDrawable.GetDuration(i);
			}
		}


		public override bool Update(long miliseconds) {
			bool active = base.Update(miliseconds);
			if (active) {
				long animationElapsedTime = 0;
				long realMiliseconds = miliseconds - mStartingMilisecond;
				if (realMiliseconds > mTotalTime) {
					if (mAnimationDrawable.OneShot) {
						return false;
					}
					realMiliseconds = realMiliseconds % mTotalTime;
				}
				for (int i=0; i<mAnimationDrawable.NumberOfFrames; i++) {
					animationElapsedTime += mAnimationDrawable.GetDuration(i);
					if (animationElapsedTime > realMiliseconds) {
						mImage = ((BitmapDrawable) mAnimationDrawable.GetFrame(i)).Bitmap;
						break;
					}
				}
			}
			return active;
		}

	}
}

