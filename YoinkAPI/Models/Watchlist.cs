using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Watchlist
    {
        public Guid? WatchlistID {get;set;}
        public Guid? FK_UserID {get;set;}
        public string? Symbol {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? DateModified {get;set;}
        public Watchlist(){}
        public Watchlist(Guid? WatchlistID, Guid? FK_UserID, string? Symbol, DateTime? DateCreated, DateTime? DateModified)
        {
            this.WatchlistID = WatchlistID;
            this.FK_UserID = FK_UserID;
            this.Symbol = Symbol;
            this.DateCreated = DateCreated;
            this.DateModified = DateModified;
        }
    }
}