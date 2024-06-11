# C#_Typing_Game

### Winform을 이용한 산성비 게임

> - groupBox와 textBox, Label, Timer, button, progressBar 컨트롤을 이용
> - Font : 맑은 고딕, 10pt, style = Bold

![image](https://github.com/khkim09/Typing_Game/assets/67762639/2607934b-9514-4b9a-a67e-763cfbab6046)
![image](https://github.com/khkim09/Typing_Game/assets/67762639/e3404030-e4db-409b-8da2-9acb0882dac6)


- issues
	- "GameOver"상태로 restart > no || quit > no 클릭 시 timer 재시작 오류 수정 (05.30)
	- Missed가 항상 HP - 5 : Game Over시 20개 Miss 고정 (단어 길이 별 체력 감소, 체력 증가 추가 - 06.11)