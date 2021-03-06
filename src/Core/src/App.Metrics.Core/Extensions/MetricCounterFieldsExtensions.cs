﻿// <copyright file="MetricCounterFieldsExtensions.cs" company="App Metrics Contributors">
// Copyright (c) App Metrics Contributors. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace
namespace App.Metrics
    // ReSharper restore CheckNamespace
{
    public static class MetricCounterFieldsExtensions
    {
        public static void Exclude(this IDictionary<CounterFields, string> metricFields, params CounterFields[] fields)
        {
            if (!fields.Any())
            {
                metricFields.Clear();

                return;
            }

            foreach (var key in fields)
            {
                if (metricFields.ContainsKey(key))
                {
                    metricFields.Remove(key);
                }
            }
        }

        public static void OnlyInclude(this IDictionary<CounterFields, string> metricFields, params CounterFields[] fields)
        {
            var counter = new Dictionary<CounterFields, string>(metricFields);

            foreach (var key in counter.Keys)
            {
                if (!fields.Contains(key))
                {
                    metricFields.Remove(key);
                }
            }
        }

        public static void Set(this IDictionary<CounterFields, string> metricFields, CounterFields field, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("metric field name cannot be null or empty", nameof(value));
            }

            if (metricFields.ContainsKey(field))
            {
                metricFields[field] = value;
            }
        }
    }
}