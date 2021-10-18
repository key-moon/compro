// detail: https://atcoder.jp/contests/code-formula-2014-qualb/submissions/26670624
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  string a, b;
  cin >> a >> b;
  var res = [&]() {
    int n = a.size();
    bool has_same = false;
    vector<int> a_cnt(26);
    vector<int> b_cnt(26);
    vector<vector<int>> v(26, vector<int>(26));
    for (int i = 0; i < n; i++) {
      has_same |= a_cnt[a[i] - 'a'] != 0;
      a_cnt[a[i] - 'a']++;
      b_cnt[b[i] - 'a']++;
      if (a[i] == b[i]) continue;
      v[a[i] - 'a'][b[i] - 'a']++;
    }

    for (int i = 0; i < 26; i++) {
      if (a_cnt[i] != b_cnt[i]) return false;
    }

    int swaps = 0;
    int si = -1;
    for (int i = 0; i < 26; i++) {
      for (int j = 0; j < 26; j++) {
        var mx = min(v[i][j], v[j][i]);
        swaps += mx;
        v[i][j] -= mx;
        v[j][i] -= mx;
        if (v[i][j] != 0) si = i;
      }
    }

    if (si != -1) {
      int cycle_len = 0;
      int i = si;
      do
      {
        int j = -1;
        for (int _j = 0; _j < 26; _j++) {
          if (v[i][_j] == 0) continue;
          j = _j;
          break;
        }
        if (j == -1) return false;
        v[i][j]--;
        cycle_len++;
        i = j;
      } while (i != si);
      swaps += cycle_len - 1;
    }

    for (int i = 0; i < 26; i++) {
      for (int j = 0; j < 26; j++) {
        if (v[i][j] != 0) return false;
      }
    }

    if (swaps == 3 || swaps == 1 || (has_same && swaps <= 3)) return true;
    return false;
  }();

  cout << (res ? "YES" : "NO") << endl;
}