using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the Model to create a new Watchlist - contains WatchlistID, FK_UserID, Symbol, DateCreated, DateModified
    /// </summary>
    public class Watchlist
    {
        public Guid? WatchlistID {get;set;}
        public Guid? FK_UserID {get;set;}
        public string? Symbol {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? DateModified {get;set;}

        /// <summary>
        /// This is the Constructor to create a new Watchlist that is empty
        /// </summary>
        public Watchlist(){}

        /// <summary>
        /// This is the Constructor to create a new Watchlist - contains WatchlistID, FK_UserID, Symbol, DateCreated, DateModified
        /// </summary>
        /// <param name="WatchlistID"></param>
        /// <param name="FK_UserID"></param>
        /// <param name="Symbol"></param>
        /// <param name="DateCreated"></param>
        /// <param name="DateModified"></param>
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