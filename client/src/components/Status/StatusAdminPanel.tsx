import { Close, Save, Add } from "@mui/icons-material";
import { Box, Button, Dialog, TextField, Typography } from "@mui/material";
import React, { useEffect, useRef, useState } from "react";
import {
  createStatus,
  deleteStatusById,
  getAllStatuses,
  updateStatus,
} from "../../api/statusRequest";
import { Status } from "../../models/status";
import { StatusRow } from "./StatusRow";

export const StatusAdminPanel: React.FC = () => {
  const [statuses, setStatuses] = useState<Status[]>();
  const [isVisible, setIsVisible] = useState<boolean>(false);
  const [selectedStatus, setSelectedStatus] = useState<Status>();
  const [title, setTitle] = useState<string>("");
  const statusName = useRef<string>("");

  const onDelete = async (id: number) => {
    await deleteStatusById(id);
    const response = await getAllStatuses();
    setStatuses(response);
  };
  const openEditDialog = (status: Status) => {
    setSelectedStatus(status);
    setIsVisible(true);
  };
  const onChangeSaved = async () => {
    setIsVisible(false);
    if (selectedStatus !== undefined) {
      await updateStatus(selectedStatus);
    } else {
      await createStatus(statusName.current);
    }
    const response = await getAllStatuses();
    setStatuses(response);
    setSelectedStatus(undefined);
  };

  useEffect(() => {
    (async () => {
      const response = await getAllStatuses();
      setStatuses(response);
    })();
  }, []);
  return (
    <div style={{ width: 500 }}>
      {statuses?.map((x) => (
        <StatusRow
          key={x.id}
          text={x.name}
          onDelete={() => {
            onDelete(x.id);
          }}
          onEdit={() => {
            setTitle("Изменить");
            openEditDialog(x);
          }}
        />
      ))}
      <Button
        onClick={() => {
          setTitle("Добавить");
          setIsVisible(true);
        }}
      >
        <Add />
      </Button>
      <Dialog open={isVisible}>
        <Box
          style={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "space-around",
            alignItems: "center",
          }}
          width={400}
          height={200}
        >
          <Typography
            fontWeight={700}
            fontSize={25}
            style={{ alignSelf: "center", justifyItems: "start" }}
          >
            {title}
          </Typography>
          <Close
            onClick={() => {
              setIsVisible(false);
              setSelectedStatus(undefined);
            }}
            style={{ position: "absolute", top: 0, right: 0, cursor: "hand" }}
          ></Close>
          <div
            style={{
              alignSelf: "center",
              display: "flex",
              flexDirection: "row",
            }}
          >
            <TextField
              onChange={(e) => {
                if (selectedStatus !== undefined) {
                  setSelectedStatus({
                    id: selectedStatus!.id,
                    name: e.target.value,
                  });
                } else {
                  statusName.current = e.target.value;
                }
              }}
              value={selectedStatus?.name}
            ></TextField>
            <Button onClick={onChangeSaved} variant="contained">
              <Save></Save>
            </Button>
          </div>
        </Box>
      </Dialog>
    </div>
  );
};
