using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class ExplosionPhysicsForce : MonoBehaviour
    {
        public float explosionForce = 4;


        private IEnumerator Start()
        {
            // wait one frame because some explosions instantiate debris which should then
            // be pushed by physics force
            yield return null;

            float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;

            float r = 10*multiplier;
            var cols = Physics2D.OverlapCircleAll(transform.position, r);
            var rigidbodies = new List<Rigidbody2D>();
            foreach (var col in cols)
            {
                if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                {
                    rigidbodies.Add(col.attachedRigidbody);
                }
            }
            foreach (var rb in rigidbodies)
            {
                Vector2 forceToBeApplied = Vector3.Normalize(rb.transform.position - transform.position) * explosionForce * multiplier;
                rb.AddForceAtPosition(forceToBeApplied, rb.transform.position, ForceMode2D.Impulse);
            }
        }
    }
}
