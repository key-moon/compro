// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1166/judge/5192909/C++17
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;
int main(){
  int w, h;
  while (cin >> w >> h, h){
    vector<vector<int>> graph(h * w);
    var addedge = [&](int y1, int x1, int y2, int x2){
      graph[y1 * w + x1].push_back(y2 * w + x2);
      graph[y2 * w + x2].push_back(y1 * w + x1);
    };
    for (int i = 0; i < h; i++){
      for (int j = 0; j < w - 1; j++){
        int wall;
        cin >> wall;
        if (wall) continue;
        addedge(i, j, i, j + 1);
      }
      if (i == h - 1) continue;
      for (int j = 0; j < w; j++){
        int wall;
        cin >> wall;
        if (wall) continue;
        addedge(i, j, i + 1, j);
      }
    }
    vector<int> len(h * w);
    queue<int> queue{};
    len[0] = 1;
    queue.push(0);
    while (!queue.empty()){
      var elem = queue.front(); queue.pop();
      for (var adj : graph[elem]){
        if (len[adj]) continue;
        len[adj] = len[elem] + 1;
        queue.push(adj);
      }
    }
    cout << len[h * w - 1] << endl;
  }
}

