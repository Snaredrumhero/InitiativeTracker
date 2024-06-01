using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace InitiativeTracker
{
    public class Combat
    {
        public List<Player> Players;
        public List<Enemy> Enemies;
        public int GlobalTurnCounter;
        public int CurrentInitiative;
        [JsonIgnore]
        public IEnumerable<ICombatant> Combatants => [..Players, ..Enemies];
        public IEnumerable<Stack<UndoData>> UndoStack;

        public Combat(List<Player> players, List<Enemy> enemies, int? globalTurnCounter = null, int? currentInitiative = null)
        {
            Players = players;
            Enemies = enemies;
            Initialize(globalTurnCounter, currentInitiative);
        }

        private void Initialize(int? globalTurnCounter = null, int? currentInitiative = null)
        {
            GlobalTurnCounter = globalTurnCounter ?? 1;

            if (currentInitiative is not null)
            {
                if (Combatants.Any(z => z.Initiative == currentInitiative))
                {
                    CurrentInitiative = currentInitiative.Value;
                }
                else
                {
                    throw new InvalidDataException("CurrentInitiative does not correspond to any combatants");
                }
            }
            else
            {
                CurrentInitiative = Combatants.Max(z => z.Initiative);
                var current = UpNow();
                var currentArray = current.ToArray();
                var currentList = currentArray.ToList();
            }
        }

        public IEnumerable<ICombatant> UpNow()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICombatant> UpNext()
        {
            throw new NotImplementedException();
        }

        //True if move succeeded, false otherwise
        public bool TryMoveNext(bool overrideHeldActions = false)
        {
            return TryMoveNext(out _, overrideHeldActions);
        }

        public bool TryMoveNext(out IEnumerable<MoveResult> results, bool overrideHeldActions = false)
        {
            throw new NotImplementedException();
        }

        public void MovePrevious()
        {
            throw new NotImplementedException();
        }
    }
}
