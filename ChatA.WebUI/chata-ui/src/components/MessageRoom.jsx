const MessageRoom = ({ id, handleSelectedRoom, title, type }) => {
  const onClick = () => handleSelectedRoom(id);
  const renderRoom = () => {
    if (type === 1) return <li className="message-room-type"> Group Room</li>;
    else return <li className="message-room-type"> Individual Room</li>;
  };
  return (
    <div onClick={() => onClick()} className="message-room">
      {title}
      {renderRoom()}
    </div>
  );
};
export default MessageRoom;
