﻿using System;

namespace JG.ParticleEngine.Initializers
{
	public interface IParticleInitializer
	{
		void InitParticle(Particle p, Random r);
	}
}

