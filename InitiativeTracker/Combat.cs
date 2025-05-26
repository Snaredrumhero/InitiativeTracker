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
        public CombatState CurrentState { get; set; }
        [JsonIgnore]
        public IEnumerable<ICombatant> Combatants => [..Players, ..Enemies];
        public IEnumerable<Stack<UndoData>> UndoStack;

        public Combat(List<Player> players, List<Enemy> enemies, CombatState? currentState = null)
        {
            Players = players;
            Enemies = enemies;
            Initialize(currentState);
        }

        private void Initialize(CombatState? currentState = null)
        {
            if (currentState is null)
            {
                CurrentState = new CombatState(1, Combatants.Max(z => z.Initiative));
                var current = UpNow();
                var currentArray = current.ToArray();
                var currentList = currentArray.ToList();
                UndoStack = new List<Stack<UndoData>> { new Stack<UndoData>(new[] { new UndoData(Combatants, CurrentState.Initiative, CurrentState.Turn) }) };
            }
            else
            {
                if (Combatants.Any(z => z.Initiative == currentState.Value.Initiative))
                {
                    CurrentState = currentState.Value;
                    throw new NotImplementedException("Need to implement logic to import saved combat from a file or other source");
                }
                else
                {
                    throw new InvalidDataException("CurrentInitiative does not correspond to any combatants");
                }
            }
        }

        public IEnumerable<ICombatant> UpNow() => UpOn(CurrentState.Initiative);

        public IEnumerable<ICombatant> UpNext() => UpOn(NextInitiative.Initiative);

        public CombatState NextInitiative => Combatants.Select(z => new CombatState(CurrentState.Turn, z.Initiative))
            .Where(z => z.Initiative < CurrentState.Initiative)
            .DefaultIfEmpty(new CombatState(CurrentState.Turn + 1, HighestInitiative)).Max();

        public int HighestInitiative => Combatants.Max(z => z.Initiative);

        public CombatState PreviousInitiative => Combatants.Select(z => new CombatState(CurrentState.Turn, z.Initiative))
            .Where(z => z.Initiative > CurrentState.Initiative)
            .DefaultIfEmpty(new CombatState(CurrentState.Turn - 1, LowestInitiative)).Min();

        public int LowestInitiative => Combatants.Min(z => z.Initiative);

        public IEnumerable<ICombatant> UpOn(int initiative) => Combatants.Where(z => z.Initiative == initiative);
        

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

    public struct CombatState
    {
        public int Turn { get; set; }
        public int Initiative { get; set; }

        public CombatState(int turn, int initiative)
        {
            Turn = turn;
            Initiative = initiative;
        }
    }
}
