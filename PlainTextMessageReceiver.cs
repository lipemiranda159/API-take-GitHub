﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using System.Diagnostics;
using Take.Blip.Client;

namespace MyBot
{
    /// <summary>
    /// Defines a class for handling messages. 
    /// This type must be registered in the application.json file in the 'messageReceivers' section.
    /// </summary>
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly ISender _sender;
        private readonly Settings _settings;
    
        public PlainTextMessageReceiver(ISender sender, Settings settings)
        {
            _sender = sender;
            _settings = settings;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Console.WriteLine(message.Content.ToString());
        }
    }
}
