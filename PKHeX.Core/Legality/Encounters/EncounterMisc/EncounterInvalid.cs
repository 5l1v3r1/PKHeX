﻿using System;

namespace PKHeX.Core
{
    /// <summary>
    /// Invalid Encounter Data
    /// </summary>
    public sealed class EncounterInvalid : IEncounterable
    {
        public static readonly EncounterInvalid Default = new EncounterInvalid();

        public int Species { get; }
        public int Form { get; }
        public int LevelMin { get; }
        public int LevelMax { get; }
        public bool EggEncounter { get; }
        public int Generation { get; set; }

        public string Name => "Invalid";
        public string LongName => "Invalid";

        private EncounterInvalid() { }

        public EncounterInvalid(PKM pkm)
        {
            Species = pkm.Species;
            Form = pkm.AltForm;
            LevelMin = pkm.Met_Level;
            LevelMax = pkm.CurrentLevel;
            EggEncounter = pkm.WasEgg;
            var gen = pkm.GenNumber;
            if (gen <= 0)
                gen = pkm.Format;
            Generation = gen;
        }

        public PKM ConvertToPKM(ITrainerInfo SAV) => ConvertToPKM(SAV, EncounterCriteria.Unrestricted);
        public PKM ConvertToPKM(ITrainerInfo SAV, EncounterCriteria criteria) => throw new ArgumentException($"Cannot convert an {nameof(EncounterInvalid)} to PKM.");
    }
}
