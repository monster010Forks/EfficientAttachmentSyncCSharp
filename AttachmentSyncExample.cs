
// The 3 events found in this file are REQUIRED somewhere in your gamemode!

public class AttachmentSyncExample : Script
{
    public AttachmentSync()
    {
        Console.WriteLine( "[SYNC] AttachmentSync Initialized!" );
    }
    
    //REQUIRED
    [ServerEvent( Event.PlayerConnected )]
    public void OnPlayerConnect( Client client )
    {
        // reset data on connect
        client.ClearAttachments( );
    }

    //REQUIRED
    [RemoteEvent( "staticAttachments.Add" )]
    private void OnStaticAttachmentAdd( Client client, string hash )
    {
        client.AddAttachment( Base36Extensions.FromBase36( hash ), false );
    }
    
    //REQUIRED
    [RemoteEvent( "staticAttachments.Remove" )]
    private void OnStaticAttachmentRemove( Client client, string hash )
    {
        client.AddAttachment( Base36Extensions.FromBase36( hash ), true );
    }
    
    [Command( "addattachment" )]
    private void CMD_AddAttachment( Client client ) 
    {
        // Make sure you've registered this attachment on the client-side, check rootcause's example in ragempdev's package to see how.
        if( client.HasAttachment( "char_creator_1" ) )
            client.AddAttachment( "char_creator_1", true );
        else 
            client.AddAttachment( "char_creator_1", false );
    }
}
