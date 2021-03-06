﻿using System.Threading.Tasks;
using Windows.Storage;

namespace kmd.Storage.Contracts
{
    public interface IFileLauncher
    {
        Task LaunchAsync(IStorageFile file, bool displayApplicationPicker = false);
    }
}
