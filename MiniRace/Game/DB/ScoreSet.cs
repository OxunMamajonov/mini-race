//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniRace.Game.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ScoreSet
    {
        public int ScoreId { get; set; }
        public string Ammount { get; set; }
        public string Time { get; set; }
        public int Player_PlayerId { get; set; }
    
        public virtual PlayerSet PlayerSet { get; set; }
    }
}