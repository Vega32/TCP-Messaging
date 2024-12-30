# TCP-Messaging
## Inctroduction
This is a TCP based messaging app. It connects users using a peer-to-peer model meaning that there is no external server controlling the message passing. Instead, on of the users hosts a server (referred to as a chat room) on their machine and others can connect to it.
## User Guide
In order to use this app, you’ll need to enable TCP connections to a specific port on your machine to avoid having your firewall block incoming connections. Then you can either host or join a chat room. To host a chat room, you’ll need to enter the port that you enabled previously. The software will then give you the IP address you need to share for people to join you. To join a chat room, you’ll need to enter both the IP and port of the hosting machine. As of right now, the software is limited to only sending short text messages (so no images or other media yet).
