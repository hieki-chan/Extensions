using System.Collections.Generic;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace UnityE.Extensions
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Converts a <see cref="Vector3"/> to a <see cref="Vector3Int"/>
        /// </summary>
        /// <param name="vector">vector3Int</param>
        /// <returns><see cref="Vector3Int"/></returns>
        public static Vector3Int ToVector3Int(this Vector3 vector)
        {
            return new Vector3Int((int)vector.x, (int)vector.y, (int)vector.z);
        }

        /// <summary>
        /// Converts a <see cref="Vector3Int"/> to a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns><see cref="Vector3"/>.</returns>
        public static Vector3 ToVector3(this Vector3Int vector)
        {
            return new Vector3(vector.x, vector.y, vector.z);
        }

        /// <summary>
        /// Set x value.
        /// </summary>
        public static Vector3 SetX(this Vector3 source, float x, OperationOptions option = OperationOptions.Change)
            => new Vector3(source.x.Math(x, option), source.y, source.z);

        /// <summary>
        /// Set y value.
        /// </summary>
        public static Vector3 SetY(this Vector3 source, float y, OperationOptions option = OperationOptions.Change)
            => new Vector3(source.x, source.y.Math(y, option), source.z);

        /// <summary>
        /// Set z value
        /// </summary>
        public static Vector3 SetZ(this Vector3 source, float z, OperationOptions option = OperationOptions.Change)
            => new Vector3(source.x, source.y, source.z.Math(z, option));

        /// <summary>
        /// Adds random noise to a Vector3 based on the specified strength.
        /// </summary>
        /// <param name="source">The original Vector3.</param>
        /// <param name="strength">The strength of the noise effect.</param>
        /// <returns>A new <see cref="Vector3"/> with random noise added to.</returns>
        public static Vector3 GetNoise(this Vector3 source, float strength)
        {
            return new Vector3(source.x + UnityRandom.Range(-1.0f, 1.0f) * strength,
                source.y + UnityRandom.Range(-1.0f, 1.0f) * strength,
                source.z + UnityRandom.Range(-1.0f, 1.0f) * strength);
        }

        /// <summary>
        /// Generates Perlin noise for a Vector2 based on the specified strength.
        /// </summary>
        /// <param name="source">The original Vector2.</param>
        /// <param name="strength">The strength of the noise effect.</param>
        /// <returns>A new <see cref="Vector2"/> with Perlin noise generated based on the specified strength.</returns>
        public static Vector2 GetNoise(this Vector2 source, float strength)
        {
            var _noise = Mathf.PerlinNoise(source.x * strength, source.y * strength);
            return new Vector2(_noise, _noise);
        }

        /// <summary>
        /// Get Flat of vector.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>A new <see cref="Vector3"/> with y-value equal to zero.</returns>
        public static Vector3 ToFlat(this Vector3 source)
        {
            return new Vector3(source.x, 0, source.z);
        }

        /// <summary>
        /// Finds the position closest to the given one.
        /// </summary>
        /// <param name="position">World position.</param>
        /// <param name="otherPositions">Other world positions.</param>
        /// <returns>Closest position.</returns>
        public static Vector3 FindClosest(this Vector3 position, IEnumerable<Vector3> otherPositions)
        {
            Vector3 closest = Vector3.zero;
            float shortestDistance = Mathf.Infinity;

            foreach (var otherPosition in otherPositions)
            {
                float distance = (position - otherPosition).sqrMagnitude;

                if (distance < shortestDistance)
                {
                    closest = otherPosition;
                    shortestDistance = distance;
                }
            }

            return closest;
        }

        /// <summary>
        /// Finds the index of the position closest to the given one.
        /// </summary>
        public static int FindClosestIndex(this Vector3 position, IEnumerable<Vector3> otherPositions)
        {
            float shortestDistance = Mathf.Infinity;
            int index = -1;

            foreach (var otherPosition in otherPositions)
            {
                index++;
                float distance = (position - otherPosition).sqrMagnitude;

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                }
            }

            return index;
        }
    }
}
