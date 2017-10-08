﻿using System;
using System.Linq;
using SharpLearning.Containers.Matrices;
using SharpLearning.Containers.Views;

namespace SharpLearning.Containers
{
    /// <summary>
    /// Class containing common argument checks for the learners.
    /// </summary>
    public static class Checks
    {
        /// <summary>
        /// Verify that observations and targets are valid.
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="targets"></param>
        public static void VerifyObservationsAndTargets(F64MatrixView observations, double[] targets)
        {
            VerifyObservationsAndTargets(observations.RowCount, observations.ColumnCount, targets.Length);
        }

        /// <summary>
        /// Verify that observations and targets are valid.
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="targets"></param>
        public static void VerifyObservationsAndTargets(F64Matrix observations, double[] targets)
        {
            VerifyObservationsAndTargets(observations.RowCount, observations.ColumnCount, targets.Length);
        }

        public static void VerifyObservationsAndTargets(int observationsRowCount, int observationsColumnCount, int targetLength)
        {
            VerifyObservations(observationsRowCount, observationsColumnCount);
            VerifyTargets(targetLength);
            VerifyObservationsRowCountAndTargetsLengthMatch(observationsRowCount, targetLength);
        }

        /// <summary>
        /// Verify that the observation matrix is valid.
        /// </summary>
        /// <param name="observations"></param>
        public static void VerifyObservations(int rowCount, int columnCount)
        {
            if(rowCount == 0)
            {
                throw new ArgumentException("Observations does not contain any rows");
            }

            if (columnCount == 0)
            {
                throw new ArgumentException("Observations does not contain any columns");
            }
        }

        /// <summary>
        /// Verify that the target vector is valid.
        /// </summary>
        /// <param name="targets"></param>
        public static void VerifyTargets(int targetLength)
        {
            if (targetLength == 0)
            {
                throw new ArgumentException("Targets does not contain any rows");
            }
        }

        /// <summary>
        /// Verify that observations and targets dimensions match.
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="targets"></param>
        public static void VerifyObservationsRowCountAndTargetsLengthMatch(int observationRowCount, int targetLength)
        {
            if(observationRowCount != targetLength)
            {
                throw new ArgumentException($"Observation row count: {observationRowCount} and target length: {targetLength} does not match");
            }           
        }

        /// <summary>
        /// Verify that indices match observations and targets. 
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="observations"></param>
        /// <param name="targets"></param>
        public static void VerifyIndices(int[] indices, F64MatrixView observations, double[] targets)
        {
            VerifyIndices(indices, observations.RowCount, targets.Length);
        }

        /// <summary>
        /// Verify that indices match observations and targets. 
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="observations"></param>
        /// <param name="targets"></param>
        public static void VerifyIndices(int[] indices, F64Matrix observations, double[] targets)
        {
            VerifyIndices(indices, observations.RowCount, targets.Length);
        }

        /// <summary>
        /// Verify that indices match observations and targets.
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="observations"></param>
        /// <param name="targets"></param>
        public static void VerifyIndices(int[] indices, int observationRowCount, int targetLength)
        {
            var min = indices.Min();
            if(min < 0)
            {
                throw new ArgumentException($"Indices contains negative values: {string.Join(",", indices.Where(v => v < 0))}");
            }

            var max = indices.Max();
            if (max >= observationRowCount || max >= targetLength)
            {
                throw new ArgumentException($"Indices contains elements exceeding the row count of observations and targets. Indices Max: {max}, observations row count: {observationRowCount}, target length: {targetLength}");
            }
        }
    }
}
