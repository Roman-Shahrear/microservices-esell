﻿using BuildingBlocks.Exceptions;

namespace Ordering.Application.Excepsions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid id) : base("Order", id)
        {

        }
    }
}