// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1193/judge/5193721/C++17
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;

const int W = 5;

int step(vector<vector<int>>& board){
  int n = board.size();
  int score = 0;
  for (int i = 0; i < n; i++){
    for (int j = 0; j < W; j++){
      int last = 0;
      for (last = j + 1; last < W; last++){
        if (board[i][last] != board[i][j]) break;
      }
      if (last - j < 3) continue;
      for (int k = j; k < last; k++) {
        score += board[i][k];
        board[i][k] = 0;
      }
      j = last;
    }
  }
  for (int i = n - 1; i >= 0; i--){
    for (int j = 0; j < W; j++){
      if (board[i][j] != 0) continue;
      for (int k = i; k >= 0; k--){
        if (board[k][j] == 0) continue;
        board[i][j] = board[k][j];
        board[k][j] = 0;
        break;
      }
    }
  }
  return score;
}

using namespace std;
int main(){
  int n;
  while (cin >> n, n){
    vector<vector<int>> board(n, vector<int>(5));
    for (int i = 0; i < n; i++){
      for (int j = 0; j < W; j++){
        cin >> board[i][j];
      }
    }
    int res = 0;
    int nxtScore = 0;
    do{
      nxtScore = step(board);
      res += nxtScore;
    }
    while(nxtScore != 0);
    cout << res << endl;
  }
}

