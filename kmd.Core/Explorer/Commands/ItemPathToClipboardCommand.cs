﻿using kmd.Core.Explorer.Commands.Configuration;
using kmd.Core.Services.Contracts;
using kmd.Core.Hotkeys;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.System;
using kmd.Core.Explorer.Contracts;

namespace kmd.Core.Explorer.Commands
{
    [ExplorerCommand("ItemPathToClipboard", "Item path to clipboard", ModifierKeys.Control, VirtualKey.Enter)]
    public class ItemPathToClipboardCommand : ExplorerCommandBase
    {
        public ItemPathToClipboardCommand(ICilpboardService cilpboardService)
        {
            _cilpboardService = cilpboardService ?? throw new ArgumentNullException(nameof(cilpboardService));
        }

        protected readonly ICilpboardService _cilpboardService;

        protected override bool OnCanExecute(IExplorerViewModel vm)
        {
            return vm.SelectedItem != null && vm.SelectedItem.IsPhysical;
        }

        protected override void OnExecuteAsync(IExplorerViewModel vm)
        {
            var data = new DataPackage();
            data.SetText(vm.SelectedItem.Path);
            _cilpboardService.Set(data);
        }
    }
}
