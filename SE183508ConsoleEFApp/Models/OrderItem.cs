﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SE183508ConsoleEFApp.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? Price { get; set; }

    public int? Subtotal { get; set; }

    public virtual SiOrder Order { get; set; }

    public virtual SiProduct Product { get; set; }
}