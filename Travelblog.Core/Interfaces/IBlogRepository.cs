﻿using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetAll();
    }
}
