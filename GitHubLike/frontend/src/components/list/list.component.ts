import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ListComponent {
  @Input() mainTitle?: string;
  @Input() createdBy?: string;
  @Input() extraText?: unknown | unknown[];
  @Input() greyedOut?: boolean = false;
}
