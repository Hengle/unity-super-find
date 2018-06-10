﻿using System;
using UnityEngine;

namespace SuperFindPlugin
{
    public abstract class Flair {

        public static string[] ValidWords = {
            "first",
            "last",
        };

        public static Flair FromString(string flairStr) {
            int parsed;
            bool isNumeric = int.TryParse(flairStr, out parsed);
            if (isNumeric) {
                return new IndexFlair(parsed);
            } else if (ValidateWord(flairStr)) {
                return new WordFlair(flairStr);
            } else {
                throw new Exception("Flair " + flairStr + " is not a valid flair.");
            }
        }

        public static bool ValidateWord(string word) {
            return Array.Exists(ValidWords, element => element == word);
        }

        public abstract bool Match(Transform transform, string name);
    }
}