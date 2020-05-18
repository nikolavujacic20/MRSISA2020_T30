import { UserDto } from "./UserDto";
import { LokacijaDto } from "./LokacijaDto";

export class ExamDto {
  id: number;
  datetime?: Date;
  examType?: string;
  anameza?: string;
  zakljucak?: string;
  locationId?: number;
  pacijentId?: number;
  doctorId?: number;
  price?: number;
  discountPrice?: number;
  taken?: number;

  doctor?: UserDto;
  pacijent?: UserDto;
  location?: LokacijaDto;
}
