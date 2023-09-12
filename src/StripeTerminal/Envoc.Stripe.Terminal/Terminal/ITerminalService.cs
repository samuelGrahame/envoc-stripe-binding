﻿using StripeTerminal.Connectivity;
using StripeTerminal.Payment;

namespace StripeTerminal;

public interface ITerminalService
{
    event EventHandler<RefreshReaderEventArgs> RefreshReader;
    event EventHandler<ReaderUpdateEventArgs> ReaderUpdateProgress;
    event EventHandler<ReaderUpdateLabelEventArgs> ReaderUpdateLabel;
    event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

    bool IsTerminalConnected { get; }
    ReaderConnectivityStatus GetConnectivityStatus();

    //Task Initialize(IConnectionTokenProviderService connectionTokenProviderService);
    Task<bool> Initialize();

    Task GetWifiReaders(Action<IList<Reader>> readers, bool simulated = false);
    Task GetBluetoothReaders(Action<IList<Reader>> readers, bool simulated = false);
    Task GetReaders(StripeDiscoveryConfiguration config, Action<IList<Reader>> readers);
    Task CancelDiscovery();

    Task<Reader> ConnectReader(ReaderConnectionRequest request);
    Task<bool> DisconnectReader();
    Task<Reader> ReconnectReader();

    Task<bool> RequestPermissions();

    Task<PaymentResponse> CollectPayment(PaymentRequest payment);
    void CancelPayment();

    Task UpdateConnectedReader();
    Task SetSimulatedUpdate(bool updateRequired);
}