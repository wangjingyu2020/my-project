import React, { useEffect, useState } from 'react';
import ReactMarkdown from 'react-markdown';

const MarkdownViewer = ({ file }: { file: string }) => {
  const [content, setContent] = useState<string>('');

  useEffect(() => {
    fetch(file)
      .then((res) => res.text())
      .then((text) => setContent(text));
  }, [file]);

  return <ReactMarkdown>{content}</ReactMarkdown>;
};

export default MarkdownViewer;
