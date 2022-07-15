uses crt;
const
    WHTIE         = 15;
    BLACK         = 16;
    BLUE          = 17;
    GRAY          = 24;
    GREEN         = 26;
    CYAN          = 27;
    RED           = 28;
    YELLOW        = 30;
    
    BG_SELECT     = WHTIE;
    BG_NOT_SELECT = -1;
    MAX_N         = 8;

    SCREEN_MAX_X  = 120;
    SCREEN_MAX_Y  = 30;
    CELL_HEIGHT   = 1;
    CELL_WIDTH    = 3;
    FIRST_LINE    = (SCREEN_MAX_Y div 2) - ((MAX_N * CELL_HEIGHT) div 2);
    FIRST_COL     = (SCREEN_MAX_X div 2) - ((MAX_N * CELL_WIDTH) div 2);

    KEY_SPECIAL   = 0;
    KEY_UP        = 72;
    KEY_LEFT      = 75;
    KEY_RIGHT     = 77;
    KEY_DOWN      = 80;
    KEY_ENTER     = 13;
    KEY_SELECT    = KEY_ENTER;
    KEY_END       = 48;

    EMPTY         = 0;
    CASLTE        = 1;
    KNIGHT        = 2;
    BISHOP        = 3;
    QUEEN         = 4;
    KING          = 5;
    PAWN          = 6;

    M : array [0.. 6] of char = (' ', 'X', 'M', 'T', 'H', 'V', 'L');

type
    Point = record
        x, y : integer;
    end;
    ChessBoard = array [1..MAX_N, 1..MAX_N] of integer;
var
    topRound : boolean;
    cursor : Point;
    map : ChessBoard =
        (
            ( 1,  2,  3,  4,  5,  3,  2,  1),
            ( 6,  6,  6,  6,  6,  6,  6,  6),
            ( 0,  0,  0,  0,  0,  0,  0,  0),
            ( 0,  0,  0,  0,  0,  0,  0,  0),
            ( 0,  0,  0,  0,  0,  0,  0,  0),
            ( 0,  0,  0,  0,  0,  0,  0,  0),
            (-6, -6, -6, -6, -6, -6, -6, -6),
            (-1, -2, -3, -4, -5, -3, -2, -1)
        );

    procedure print_round();
    var mess : string;
    begin
        if (topRound) then

            mess:= '  TOP ROUND '
        else 
            mess:= 'BOTTOM ROUND';

        gotoxy(SCREEN_MAX_X div 2 - 6, SCREEN_MAX_Y div 2 + 5);
        textbackground(BLACK);
        textcolor(WHITE);
        write(mess);
    end;

    procedure print_map();
    var
        i, j, chessMan : integer;
    begin


        for i:= 1 to MAX_N do
        begin
            gotoxy(FIRST_COL, i - 1 + FIRST_LINE);
            for j:= 1 to MAX_N do
            begin
                chessMan:= abs(map[i, j]);

                if (chessMan > 0) then
                    if (map[i, j] > 0) then
                        textcolor(RED)
                    else
                        textcolor(GREEN);

                if ((i + j) mod 2 = 1) then
                    textbackground(BLUE)
                else
                    textbackground(BLACK);

                write(' ' + M[chessMan] + ' ');
            end;
        end;
    end;

    procedure print_chessMan(pos : Point; bgColor: integer);
    var chessMan : integer;
    begin
        chessMan:= abs(map[pos.y, pos.x]);
        if (chessMan > 0) then
            if (map[pos.y, pos.x] > 0) then
                textcolor(RED)
            else
                textcolor(GREEN);

        if (bgColor = BG_NOT_SELECT) then
            if ((pos.x + pos.y) mod 2 = 1) then
                bgColor := BLUE
            else
                bgColor := BLACK;
        textbackground(bgColor);

        gotoxy(FIRST_COL + (pos.x-1)*3, FIRST_LINE + pos.y - 1);
        write(' ' + M[chessMan] + ' ');
    end;

    procedure init();
    begin
        topRound:= true;
        cursor.x := 1;
        cursor.y := 1;
        print_map();
        print_chessMan(cursor, WHTIE);
        print_round();
    end;

    function isChessmanBetweenRange(startPoint, endPoint : Point) : boolean;
    var deltaX, deltaY : integer;
    begin
        deltaX := endPoint.x - startPoint.x;
        if (deltaX <> 0) then
        begin
            if (deltaX > 0) then
                deltaX:= 1
            else
                deltaX:= -1;
        end;
        
        deltaY := endPoint.y - startPoint.y;
        if (deltaY <> 0) then
        begin
            if (deltaY > 0) then
                deltaY:= 1
            else
                deltaY:= -1;
        end;        

        while (true) do
        begin
            inc(startPoint.x, deltaX);
            inc(startPoint.y, deltaY);

            if (startPoint.x = endPoint.x) and (startPoint.y = endPoint.y) then break;

            if (map[startPoint.y, startPoint.x] <> 0) then exit(false);
        end;

        exit(true);
    end;

    function checkMoveCastle(startPoint, endPoint : Point) : boolean;
    begin
        exit(((startPoint.x = endPoint.x) or (startPoint.y = endPoint.y)) and (isChessmanBetweenRange(startPoint, endPoint)));
    end;

    function checkMoveKnight(startPoint, endPoint : Point) : boolean;
    var x, y : integer;
    begin
        x := abs(startPoint.x - endPoint.x);
        y := abs(startPoint.y - endPoint.y);
        exit(x*y = 2);
    end;

    function checkMoveBishop(startPoint, endPoint : Point) : boolean;
    var x, y : integer;
    begin
        x := abs(startPoint.x - endPoint.x);
        y := abs(startPoint.y - endPoint.y);
        exit((x = y) and (isChessmanBetweenRange(startPoint, endPoint)));
    end;    

    function checkMoveQueen(startPoint, endPoint : Point) : boolean;    
    begin
        exit(checkMoveCastle(startPoint, endPoint) or checkMoveBishop(startPoint, endPoint));
    end;    

    function checkMoveKing(startPoint, endPoint : Point) : boolean;
    var x, y : integer;
    begin
        x := abs(startPoint.x - endPoint.x);
        y := abs(startPoint.y - endPoint.y);

        if (x + y = 1) and ((x = 0) or (y = 0)) then exit(true);
        if ((x = 1) or (y = 1)) and ((x + y = 2)) then exit(true);

        exit(false);
    end;

    function checkMovePawnTop(startPoint, endPoint : Point) : boolean;
    var chessManEnd : integer;
    begin
        // chessMan > 0
        {   luot dau di chuyen: 
                +) di chuyen 1 o thang cot, vi tri den o rong
                +) di chuyen 2 o thang cot, vi tri giua khong co vat can, vi tri den o rong
            luot sau di chuyen:
                +) di chuyen 1 o thang cot, vi tri den o rong
            an quan co:
                +) di chuyen cheo 1 cot, lech 1 hang, vi tri den phai co quan co            }
        chessManEnd:= map[endPoint.y, endPoint.x];

        if (startPoint.y = 2) then  // vi tri xuat phat
            // di chuyen 2 o thang di den o trong, k co vat can
            if (startPoint.x = endPoint.x) and (endPoint.y = startPoint.y + 2) and (map[startPoint.y + 1, startPoint.x] = EMPTY) and (chessManEnd = EMPTY) then exit(true);

        if (startPoint.y >= 2) then 
        begin
            // di chuyen 1 o cheo, vi tri den la quan co dich
            if (abs(startPoint.x - endPoint.x) = 1) and (endPoint.y = startPoint.y + 1) and (chessManEnd < 0) then exit(true);

            // di chuyen 1 o thang di den o trong
            if (startPoint.x = endPoint.x) and (endPoint.y = startPoint.y + 1) and (chessManEnd = EMPTY) then exit(true);
        end;

        exit(false);
    end;

    function checkMovePawnBottom(startPoint, endPoint : Point) : boolean;
    var chessManEnd : integer;
    begin
        chessManEnd:= map[endPoint.y, endPoint.x];

        if (startPoint.y = 7) then  // vi tri xuat phat
            // di chuyen 2 o thang di den o trong, k co vat can
            if (startPoint.x = endPoint.x) and (endPoint.y = startPoint.y - 2) and (map[startPoint.y - 1, startPoint.x] = EMPTY) and (chessManEnd = EMPTY) then exit(true);

        if (startPoint.y <= 7) then
        begin
            // di chuyen 1 o cheo, vi tri den la quan co dich
            if (abs(startPoint.x - endPoint.x) = 1) and (endPoint.y = startPoint.y - 1) and (chessManEnd > 0) then exit(true);

            // di chuyen 1 o thang di den o trong
            if (startPoint.x = endPoint.x) and (endPoint.y = startPoint.y - 1) and (chessManEnd = EMPTY) then exit(true);
        end;

        exit(false);
    end;

    function checkMovePawn(startPoint, endPoint : Point) : boolean;
    var chessMan : integer;
    begin
        chessMan:= map[startPoint.y, startPoint.x];
        if (chessMan > 0) then 
            exit(checkMovePawnTop(startPoint, endPoint))
        else 
            exit(checkMovePawnBottom(startPoint, endPoint));
    end;

    function checkMove(startPoint, endPoint : Point) : boolean;
    var chessMan : integer;
    begin
        if (startPoint.x = endPoint.x) and (startPoint.y = endPoint.y) then exit(false);
        chessMan:= map[startPoint.y, startPoint.x];

        if (chessMan * map[endPoint.y, endPoint.x] > 0) then exit(false);

        case abs(chessMan) of 
            CASLTE:  // xe
                exit(checkMoveCastle(startPoint, endPoint));
            
            KNIGHT:  // ma
                exit(checkMoveKnight(startPoint, endPoint));

            BISHOP: // tuong
                exit(checkMoveBishop(startPoint, endPoint));

            QUEEN: // hau
                exit(checkMoveQueen(startPoint, endPoint));

            KING: // vua
                exit(checkMoveKing(startPoint, endPoint));

            PAWN: // linh
                exit(checkMovePawn(startPoint, endPoint));
        end;

        exit(false);
    end;

    procedure process();
    var ch, kitu : char;
        selectStart, selectEnd : Point;
    begin
        selectStart.x:= -1;
        selectEnd.x:= -1;

        while (true) do
        begin

            if (keypressed) then
            begin            
                ch:= readkey;
                case ord(ch) of
                    KEY_SPECIAL:
                    begin
                        print_chessMan(cursor, BG_NOT_SELECT);

                        kitu:= readkey;
                        case ord(kitu) of
                            KEY_UP: 
                                dec(cursor.y);

                            KEY_LEFT: 
                                dec(cursor.x);

                            KEY_RIGHT: 
                                inc(cursor.x);

                            KEY_DOWN: 
                                inc(cursor.y);
                        end;

                        if (cursor.x < 1) then cursor.x := MAX_N
                        else if (cursor.y < 1) then cursor.y := MAX_N
                        else if (cursor.x > MAX_N) then cursor.x := 1
                        else if (cursor.y > MAX_N) then cursor.y := 1;

                        print_chessMan(cursor, BG_SELECT);                        
                    end;
                    
                    KEY_SELECT:
                    begin
                        if (selectStart.x = -1) then
                        begin
                            if ((topRound) and (map[cursor.y, cursor.x] > 0)) or ((not topRound) and (map[cursor.y, cursor.x] < 0)) then
                            begin
                                selectStart:= cursor;
                                selectEnd.x:= -1;
                            end;
                        end
                        else // da co vi tri dau
                        begin
                            selectEnd := cursor;
                            // check selectEnd
                            // move if true
                            if (checkMove(selectStart, selectEnd)) then
                            begin
                                if (abs(map[selectEnd.y, selectEnd.x]) = KING) then // check end game
                                begin
                                    gotoxy(1, 1);
                                    textbackground(BLACK);
                                    textcolor(WHITE);
                                    write('END GAME');
                                    exit();
                                end;

                                map[selectEnd.y, selectEnd.x] := map[selectStart.y, selectStart.x];
                                map[selectStart.y, selectStart.x] := 0;
                                topRound:= not topRound;                                
                            end;
                            // clear color
                            print_chessMan(selectStart, BG_NOT_SELECT);
                            print_chessMan(selectEnd, BG_SELECT);
                            // reset selectStart selectEnd
                            selectStart.x:= -1;
                            selectEnd.x:= -1;
                        end;
                        
                    end;

                    KEY_END:
                        exit();
                end;

                if (selectStart.x <> -1) then
                begin
                    print_chessMan(selectStart, YELLOW);
                end;                         

                print_round();
            end;
        end;
    end;

begin
    clrscr;
    init();
    process();
    readln
end.