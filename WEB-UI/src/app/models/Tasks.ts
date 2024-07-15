import { StatusEnum } from '../enum/StatusEnum';

export interface Tasks {
  id: number;
  title: string;
  summary: string;
  status: StatusEnum;
  createdAt: Date;
  dueDate: Date;
  userId: number;
}
