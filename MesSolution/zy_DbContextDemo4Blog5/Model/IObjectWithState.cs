using System.Collections.Generic;

//QQ群：33353329
//blog：oppoic.cnblogs.com

namespace DbContexts.Model
{
    public interface IObjectWithState
    {
        State State { get; set; }
    }

    public enum State
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
