import { Edit, Delete } from "@mui/icons-material";
import { Button, Typography } from "@mui/material";
import React from "react";

export type StatusRowProps = {
  onEdit: () => void;
  onDelete: () => void;
  text: string;
};
export const StatusRow: React.FC<StatusRowProps> = ({
  text,
  onEdit,
  onDelete,
}) => {
  return (
    <div
      style={{
        justifyContent: "space-between",
        display: "flex",
        height: "auto",
        // width: 450,
        flexDirection: "row",
      }}
    >
      <Typography fontSize={25}>{text}</Typography>
      <div>
        <Button
          onClick={onEdit}
          style={{ margin: 5 }}
          color="primary"
          variant="contained"
        >
          <Edit></Edit>
        </Button>
        <Button onClick={onDelete} color="error" variant="outlined">
          <Delete></Delete>
        </Button>
      </div>
    </div>
  );
};
