
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Session1
{

using System;
    using System.Collections.Generic;
    
public partial class Demands
{

    public int id { get; set; }

    public int AgentId { get; set; }

    public int ClientId { get; set; }

    public string ObjectType { get; set; }

    public string Address_City { get; set; }

    public string Address_Street { get; set; }

    public string Address_House { get; set; }

    public string Address_Number { get; set; }

    public Nullable<int> MinPrice { get; set; }

    public Nullable<int> MaxPrice { get; set; }

    public Nullable<double> MinArea { get; set; }

    public Nullable<double> MaxArea { get; set; }

    public Nullable<int> MinRooms { get; set; }

    public Nullable<int> MaxRooms { get; set; }

    public Nullable<int> MinFloor { get; set; }

    public Nullable<int> MaxFloor { get; set; }



    public virtual Client Client { get; set; }

    public virtual Realtor Realtor { get; set; }

}

}
