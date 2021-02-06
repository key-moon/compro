#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;

int main() {
  int n, m;
  cin >> n >> m;
  vector<int> creator(n);
  for (int i = 0; i < n; i++) {
    cin >> creator[i]; creator[i]--;
  }
  int p, q;
  cin >> p >> q;
  vector<vector<bool>> follow_user(m, vector<bool>(m, false));
  for (int i = 0; i < p; i++){
    int a, b;
    cin >> a >> b; a--; b--;
    follow_user[a][b] = true;
  }
  vector<vector<bool>> follow_story(m, vector<bool>(n, false));
  vector<vector<bool>> follow_created(m, vector<bool>(m, false));
  for (int i = 0; i < q; i++){
    int a, b;
    cin >> a >> b; a--; b--;
    follow_story[a][b] = true;
    follow_created[a][creator[b]] = true;
  }
  vector<vector<bool>> follow_same_story(m, vector<bool>(m, false));
  for (int i = 0; i < n; i++){
    vector<int> users{};
    for (int j = 0; j < m; j++){
      if (follow_story[j][i]) users.emplace_back(j);
    }
    for (var&& item1 : users){
      for (var&& item2 : users){
        follow_same_story[item1][item2] = true;
      } 
    }
  }
  using P = pair<int, int>;
  for (int i = 0; i < m; i++){
    vector<P> stories{};
    for (int k = 0; k < n; k++){
      if (creator[k] == i || follow_story[i][k]) {
        stories.emplace_back(1, k + 1);
        continue;
      }
      int score = 0;
      for (int j = 0; j < m; j++){
        int a = 0;
        if (i == j) a = 0;
        else if (follow_user[i][j]) a = 3;
        else if (follow_created[i][j]) a = 2;
        else if (follow_same_story[i][j]) a = 1;

        int b = 0;
        if (creator[k] == j) b = 2;
        else if (follow_story[j][k]) b = 1;
        score += a * b;
      }
      stories.emplace_back(-score, k + 1);
    }
    sort(stories.begin(), stories.end());
    cout << stories[0].second << " " << stories[1].second << " " << stories[2].second << endl;
  }
}
