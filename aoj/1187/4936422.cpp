// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1187/judge/4936422/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

bool hasprev = false;

signed main() {
  int length, n, p, m;
  cin >> length >> n >> p >> m;
  if (length == 0) return 0;
  
  //間違えた数
  //同順位のケア
  
  vector<int> solves(n);
  vector<vector<int>> wacount(n, vector<int>(m));
  vector<int> penas(n);

  for (int i = 0; i < m; i++){
    int time, team, prob, jud;
    cin >> time >> team >> prob >> jud;
    team--; prob--;
    if (jud == 0){
      solves[team]++;
      penas[team] += time;
      penas[team] += wacount[team][prob] * 20;
    }
    else{
      wacount[team][prob]++;
    }
  }
  int pmax = accumulate(penas.begin(), penas.end(), 0, [](int a, int b){return max(a, b);});
  vector<vector<vector<int>>> teams(p + 1, vector<vector<int>>(pmax + 1));
  for (int i = 0; i < n; i++){
    teams[solves[i]][penas[i]].push_back(i + 1);
  }
  bool notfirst = false;
  for (int i = p; i >= 0; i--){
    for (int j = 0; j <= pmax; j++){
      if (teams[i][j].size() == 0) continue;
      sort(teams[i][j].begin(), teams[i][j].end());
      if (notfirst) cout << ',';
      notfirst = true;
      int init = teams[i][j].size() - 1;
      for (int k = init; k >= 0; k--){
        if (k != init) cout << '=';
        cout << teams[i][j][k];
      }
    }
  }
  cout << endl;
  main();
}

