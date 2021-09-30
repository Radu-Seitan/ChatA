import MessageForm from "./MessageForm";
import MyMessage from "./MyMessage";
import TheirMessage from "./TheirMessage";
import RoomHeader from "./RoomHeader";

const ChatFeed = () => {


    return (
        <div className="chat-feed">
            <RoomHeader/>
            ChatFeed
            <TheirMessage/>
            <TheirMessage/>
            <MyMessage/>
            <TheirMessage/>
            <MessageForm />
        </div>
    );
}

export default ChatFeed;