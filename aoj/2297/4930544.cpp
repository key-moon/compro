// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2297/judge/4930544/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

using uint = unsigned int;

signed main() {
  int n;
  cin >> n;

  var show = [&](uint mask){
    return;
    for (int i = 0; i < 4; i++){
      for (int j = 0; j < 4; j++){
        cout << ((mask >> (i * 4 + j) & 1) ? '#' : '.');
      }
      cout << endl;
    }
  };

  vector<uint> masks{};
  for (int i = 0; i < n; i++){
    int h, w;
    cin >> h >> w;
    for (int y = -3; y <= 3; y++){
      for (int x = -3; x <= 3; x++){
        uint mask = 0;
        int miny = clamp(y, 0, 3);
        int maxy = clamp(y + h - 1, 0, 3);
        int minx = clamp(x, 0, 3);
        int maxx = clamp(x + w - 1, 0, 3);
        for (int i = miny; i <= maxy; i++){
          for (int j = minx; j <= maxx; j++){
            mask |= (1U << (i * 4 + j));
          }
        }
        masks.push_back(mask);
      }
    }
  }
  sort(masks.begin(), masks.end());
  masks.erase(unique(masks.begin(), masks.end()), masks.end());
  int m = masks.size();

  for (int i = 0; i < m; i++){
    show(masks[i]);
  }

  uint lasts[3] = {0, 0, 0};
  for (int i = 0; i < 4; i++){
    for (int j = 0; j < 4; j++){
      char c;
      cin >> c;
      var ind = c == 'R' ? 0 : c == 'G' ? 1 : 2;
      lasts[ind] |= 1 << (i * 4 + j);
    }
  }

  for (int i = 0; i < 3; i++){
    show(lasts[i]);
  }

  uint allmask = UINT32_MAX;

  vector<int> steps(1 << 16, -1);
  queue<int> q{};
  q.push(0);
  steps[0] = 0;
  while (!q.empty()){
    var elem = q.front(); q.pop();
    for (int i = 0; i < m; i++){
      var mask = masks[i];
      var removed = elem & (allmask - mask);
      for (int j = 0; j < 3; j++){
        var next = removed | (lasts[j] & mask);
        if (steps[next] != -1) continue;
        q.push(next);
        steps[next] = steps[elem] + 1;
      }
    }
  }
  cout << steps.back() << endl;
}

