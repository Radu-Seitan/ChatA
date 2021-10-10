import TextareaAutosize from "@mui/material/TextareaAutosize";

const MessageForm = () => {
  return (
    <div className="message-form">
      <TextareaAutosize
        aria-label="empty textarea"
        placeholder="Type your message"
        style={{ width: 200 }}
      />
    </div>
  );
};
export default MessageForm;
